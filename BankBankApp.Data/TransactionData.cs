using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public class TransactionData : ITransactionData
	{
		private readonly AppDbContext _context;
		public TransactionData(AppDbContext context)
		{
			_context = context;
		}
		public Task<Transaction> Add(Transaction entity)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var transaction = await _context.Transactions.FindAsync(id);
				if (transaction == null)
				{
					throw new Exception("Transaction not found");
				}
				_context.Transactions.Remove(transaction);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<Transaction> Deposit(Transaction transaction)
		{
			try
			{
				transaction.TransactionCategoryId = 4;
				var account = await _context.Accounts.FindAsync(transaction.ReceiverAccountId);

				if (account == null)
				{
					throw new Exception("Account not found");
				}

				transaction.SourceAccountId = account.AccountId;
				account.Balance += transaction.Amount;
				transaction.Status = "Success";
				transaction.TransactionDate = DateTime.Now;

				_context.Accounts.Update(account);
				await _context.Transactions.AddAsync(transaction);
				await _context.SaveChangesAsync();

				return transaction;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}


		public async Task<Transaction> Get(int id)
		{
			try
			{
				var transaction = await _context.Transactions.FindAsync(id);
				if (transaction == null)
				{
					throw new Exception("Transaction not found");
				}
				return transaction;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Transaction>> GetAll()
		{
			try
			{
				var transactions = await _context.Transactions.ToListAsync();
				if (transactions == null || transactions.Count() == 0)
				{
					throw new Exception("No transactions found");
				}
				return transactions;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int accountId)
		{
			try
			{
				var transactions = await _context.Transactions.Where(t => t.SourceAccountId == accountId || t.ReceiverAccountId == accountId).ToListAsync();
				if (transactions == null || transactions.Count() == 0)
				{
					throw new Exception("No transactions found");
				}
				return transactions;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userId)
		{
			try
			{
				var transactions = await _context.Transactions.Where(t => t.SourceAccount.UserId == userId || t.ReceiverAccount.UserId == userId).ToListAsync();
				if (transactions == null || transactions.Count() == 0)
				{
					throw new Exception("No transactions found");
				}
				return transactions;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<Transaction> PayBill(Transaction transaction)
		{
			throw new NotImplementedException();
		}

		public async Task<Transaction> Transfer(Transaction transaction)
		{
			try
			{
				transaction.TransactionCategoryId = 1;
				var sourceAccount = await _context.Accounts.FindAsync(transaction.SourceAccountId);
				var receiverAccount = await _context.Accounts.FindAsync(transaction.ReceiverAccountId);

				if (sourceAccount == null || receiverAccount == null)
				{
					throw new Exception("Account not found");
				}

				if (sourceAccount.Balance < transaction.Amount)
				{
					throw new Exception("Insufficient funds");
				}

				sourceAccount.Balance -= transaction.Amount;
				receiverAccount.Balance += transaction.Amount;

				transaction.Status = "Success";
				transaction.TransactionDate = DateTime.Now;

				_context.Accounts.Update(sourceAccount);
				_context.Accounts.Update(receiverAccount);

				await _context.Transactions.AddAsync(transaction);
				await _context.SaveChangesAsync();
				return transaction;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public Task<Transaction> Update(Transaction entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Transaction> Withdraw(Transaction transaction)
		{
			try
			{
				transaction.TransactionCategoryId = 3;
				var account = await _context.Accounts.FindAsync(transaction.SourceAccountId);

				if (account == null)
				{
					throw new Exception("Account not found");
				}

				if (account.Balance < transaction.Amount)
				{
					throw new Exception("Insufficient funds");
				}

				account.Balance -= transaction.Amount;
				transaction.ReceiverAccountId = account.AccountId;
				transaction.Status = "Success";
				transaction.TransactionDate = DateTime.Now;

				_context.Accounts.Update(account);
				await _context.Transactions.AddAsync(transaction);
				await _context.SaveChangesAsync();
				return transaction;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}
	}
}
