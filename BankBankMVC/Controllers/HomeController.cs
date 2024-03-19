using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using Microsoft.AspNetCore.Mvc;

namespace SampleMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITransaction _transactionBLL;
		public HomeController(ITransaction transaction)
		{
			_transactionBLL = transaction;
		}
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("user") != null)
			{
				return RedirectToAction("Dashboard", "Home");
			}

			ViewData["Title"] = "BankBank";
			return View();
		}

		public IActionResult About()
		{
			ViewData["Title"] = "About Page";
			return Content("Hello from HomeController.About");
		}

		public IActionResult Dashboard()
		{
			ViewData["Title"] = "Dashboard";
			var userSession = HttpContext.Session.GetString("user");
			if (userSession == null)
			{
				return RedirectToAction("Index", "Home");
			}
			var user = JsonSerializer.Deserialize<UserViewDTO>(userSession);
			var userTransaction = _transactionBLL.GetTransactionHistory(user.UserID);
			if (userTransaction.Count() <= 1)
			{
				userTransaction = new List<TransactionHistoryDTO>();
			}
			ViewBag.Transactions = userTransaction;
			return View(user);
		}
	}
}