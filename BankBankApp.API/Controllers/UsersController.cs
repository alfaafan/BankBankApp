using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankBankApp.API.Helpers;
using BankBankApp.API.ViewModels;
using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;
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
		private readonly AppSettings _appSettings;
		public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
		{
			_userService = userService;
			_appSettings = appSettings.Value;
		}

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

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
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

				List<Claim> claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
				};
				//foreach (var role in user.Roles)
				//{
				//	claims.Add(new Claim(ClaimTypes.Role, role));
				//}

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
