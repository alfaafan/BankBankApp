using System.Text.Json;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using Microsoft.AspNetCore.Mvc;

namespace BankBankApp.MVC.Controllers
{
	public class UsersController : Controller
	{
		private readonly IUser _userBLL;
		public UsersController(IUser userBLL)
		{
			_userBLL = userBLL;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			ViewData["Title"] = "Login";
			return View();
		}

		[HttpPost]
		public IActionResult Login(UserLoginDTO user)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var userLogin = _userBLL.Login(user.Username, user.Password);
				if (userLogin != null)
				{
					ViewBag.Message = @"<div class=""alert alert-success"" role=""alert"">Login success</div>";

					var userLoginSerialized = JsonSerializer.Serialize(userLogin);
					HttpContext.Session.SetString("user", userLoginSerialized);

					return RedirectToAction("Dashboard", "Home");
				}
				else
				{
					ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">Login failed</div>";
					return View();
				}
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger text-light"" role=""alert"">" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult Register()
		{
			ViewData["Title"] = "Register";
			return View();
		}

		[HttpPost]
		public IActionResult Register(UserCreateDTO user)
		{
			ViewData["Title"] = "Register";
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				_userBLL.Create(user);
				ViewBag.Message = @"<div class=""alert alert-success"" role=""alert"">Register success</div>";
				return RedirectToAction("Login");
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		[Route("Users/Profile/Edit")]
		public IActionResult Edit()
		{
			ViewData["Title"] = "Edit Profile";
			if (HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var user = JsonSerializer.Deserialize<UserViewDTO>(HttpContext.Session.GetString("user"));
			return View(user);
		}

		[HttpPost]
		[Route("Users/Profile/Edit")]
		public IActionResult Edit(UserUpdateDTO user)
		{
			ViewData["Title"] = "Edit Profile";
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				_userBLL.Update(user);
				ViewBag.Message = @"<div class=""alert alert-success"" role=""alert"">Update success</div>";

				var userSession = HttpContext.Session.GetString("user");
				var userSessionDeserialized = JsonSerializer.Deserialize<UserViewDTO>(userSession);

				var updatedUser = _userBLL.GetByUsername(user.Username);
				HttpContext.Session.SetString("user", JsonSerializer.Serialize(updatedUser));

				return RedirectToAction("Profile");
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
				return View(user);
			}
		}

		public IActionResult Profile()
		{
			ViewData["Title"] = "Profile";
			if (HttpContext.Session.GetString("user") == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var user = JsonSerializer.Deserialize<UserViewDTO>(HttpContext.Session.GetString("user"));

			return View(user);
		}
	}
}
