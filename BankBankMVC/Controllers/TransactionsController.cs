using System.Text.Json;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using Microsoft.AspNetCore.Mvc;

namespace BankBankApp.MVC.Controllers
{
	public class TransactionsController : Controller
	{
		private readonly ITransaction _transactionBLL;
		private readonly IUser _userBLL;
		public TransactionsController(ITransaction transactionBLL, IUser userBLL)
		{
			_transactionBLL = transactionBLL;
			_userBLL = userBLL;
		}

		public IActionResult Index()
		{
			var user = JsonSerializer.Deserialize<UserViewBO>(HttpContext.Session.GetString("user"));
			if (user == null)
			{
				return RedirectToAction("Login", "Users");
			}
			var transactions = _transactionBLL.GetTransactionHistory(user.UserID);
			ViewData["Title"] = "Transaction History";
			return View(transactions);
		}

		public IActionResult Transfer()
		{
			ViewData["Title"] = "Transfer";
			return View();
		}

		[HttpPost]
		public IActionResult Transfer(TransferDTO transaction)
		{
			ViewData["Title"] = "Transfer";
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var user = JsonSerializer.Deserialize<UserViewBO>(HttpContext.Session.GetString("user"));

				transaction.SourceAccountNumber = user?.AccountNumber;
				_transactionBLL.Transfer(transaction);

				var updatedUser = _userBLL.GetByUsername(user.Username);
				HttpContext.Session.SetString("user", JsonSerializer.Serialize(updatedUser));

				ViewBag.Message = @"<div class=""alert alert-success text-light"" role=""alert"">Transfer success</div>";

				return RedirectToAction("Dashboard", "Home");
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger text-light"" role=""alert"">" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult Deposit()
		{
			ViewData["Title"] = "Deposit";
			return View();
		}

		[HttpPost]
		public IActionResult Deposit(DepositDTO transaction)
		{
			ViewData["Title"] = "Deposit";
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var user = JsonSerializer.Deserialize<UserViewDTO>(HttpContext.Session.GetString("user"));

				transaction.AccountID = user.AccountID;
				_transactionBLL.Deposit(transaction);

				var updatedUser = _userBLL.GetByUsername(user.Username);
				HttpContext.Session.SetString("user", JsonSerializer.Serialize(updatedUser));

				ViewBag.Message = @"<div class=""alert alert-success text-light"" role=""alert"">Deposit success</div>";

				return RedirectToAction("Dashboard", "Home");
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger text-light"" role=""alert"">" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult Withdraw()
		{
			ViewData["Title"] = "Withdraw";
			return View();
		}

		[HttpPost]
		public IActionResult Withdraw(WithdrawDTO transaction)
		{
			ViewData["Title"] = "Withdraw";
			if (!ModelState.IsValid)
			{
				return View();
			}

			try
			{
				var user = JsonSerializer.Deserialize<UserViewDTO>(HttpContext.Session.GetString("user"));

				transaction.AccountID = user.AccountID;
				_transactionBLL.Withdraw(transaction);

				var updatedUser = _userBLL.GetByUsername(user.Username);
				HttpContext.Session.SetString("user", JsonSerializer.Serialize(updatedUser));

				ViewBag.Message = @"<div class=""alert alert-success text-light"" role=""alert"">Withdraw success</div>";

				return RedirectToAction("Dashboard", "Home");
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class=""alert alert-danger text-light"" role=""alert"">" + ex.Message + "</div>";
				return View();
			}
		}

		public IActionResult BillPayment()
		{
			ViewData["Title"] = "Bill Payment";
			return View();
		}
	}
}
