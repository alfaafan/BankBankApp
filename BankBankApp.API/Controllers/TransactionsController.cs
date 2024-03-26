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
	public class TransactionsController : ControllerBase
	{
		private readonly ITransactionService _transactionService;
		public TransactionsController(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var transactions = await _transactionService.GetAll();
				return Ok(transactions);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving transactions");
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var transaction = await _transactionService.Get(id);
				return Ok(transaction);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving transaction");
			}
		}

		[HttpGet("account/{accountID}")]
		public async Task<IActionResult> GetByAccount(int accountID)
		{
			try
			{
				var transactions = await _transactionService.GetByAccount(accountID);
				if (transactions == null || transactions.Count() == 0)
				{
					return NotFound();
				}
				return Ok(transactions);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving transactions");
			}
		}

		[HttpPost("deposit")]
		public async Task<IActionResult> Deposit(DepositDTO transaction)
		{
			try
			{
				var createdTransaction = await _transactionService.Deposit(transaction);
				return CreatedAtAction(nameof(Get), new { id = createdTransaction.TransactionID }, createdTransaction);
			}
			catch (Exception ex)
			{	
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("withdraw")]
		public async Task<IActionResult> Withdraw(WithdrawDTO transaction)
		{
			try
			{
				var createdTransaction = await _transactionService.Withdraw(transaction);
				return CreatedAtAction(nameof(Get), new { id = createdTransaction.TransactionID }, createdTransaction);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("transfer")]
		public async Task<IActionResult> Transfer(TransferDTO transaction)
		{
			try
			{
				var createdTransaction = await _transactionService.Transfer(transaction);
				return CreatedAtAction(nameof(Get), new { id = createdTransaction.TransactionID }, createdTransaction);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
