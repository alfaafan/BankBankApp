using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankBankApp.API.Helpers;
using BankBankApp.API.ViewModels;
using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankBankApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
		private readonly AppSettings _appSettings;
		public UsersController(IUserService userService, IOptions<AppSettings> appSettings, IRoleService roleService)
		{
			_userService = userService;
			_appSettings = appSettings.Value;
			_roleService = roleService;
		}

		[Authorize(Roles = "admin")]
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var users = await _userService.GetAll();
				if (users == null || users.Count() == 0)
				{
					return NotFound();
				}
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[Authorize(Roles = "customer")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userIdClaim == null || userIdClaim.Value != id.ToString())
			{
				return Forbid();
			}
			try
			{
				var user = await _userService.GetWithAccountAndCard(id);
				if (user == null)
				{
					return NotFound();
				}
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDTO login)
		{
			try
			{
				var user = await _userService.Login(login);
				if (user == null)
				{
					return BadRequest("Invalid username or password");
				}
				var roles = await _roleService.GetUserRolesByUsername(user.Username);

				List<Claim> claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
				};
				foreach (var role in roles)
				{
					claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
				}

				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(claims),
					Expires = DateTime.UtcNow.AddHours(1),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var userWithToken = new UserWithToken
				{
					UserId = user.UserId,
					Username = user.Username,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth,
					Accounts = user.Accounts,
					Cards = user.Cards,
					Roles = roles,
					Token = tokenHandler.WriteToken(token)
				};

				return Ok(userWithToken);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(RegisterDTO user)
		{
			try
			{
				await _userService.Create(user);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _userService.Delete(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[Authorize(Roles = "customer")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UserUpdateDTO user)
		{
			try
			{
				user.UserId = id;
				await _userService.Update(user);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
