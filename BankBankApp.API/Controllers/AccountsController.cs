using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankBankApp.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAccounts()
		{
			try
			{
				var accounts = await _accountService.GetAccounts();
				if (accounts == null || accounts.Count() == 0)
				{
					return NotFound();
				}
				return Ok(accounts);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAccountById(int id)
		{
			try
			{
				var account = await _accountService.GetAccountById(id);
				if (account == null)
				{
					return NotFound();
				}
				return Ok(account);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("number/{accountNumber}")]
		public async Task<IActionResult> GetAccountByAccountNumber(string accountNumber)
		{
			try
			{
				var account = await _accountService.GetAccountByAccountNumber(accountNumber);
				if (account == null)
				{
					return NotFound();
				}
				return Ok(account);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAccount(int id, AccountDTO account)
		{
			try
			{
				var updatedAccount = await _accountService.UpdateAccount(account);
				return Ok(updatedAccount);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

	}
}
