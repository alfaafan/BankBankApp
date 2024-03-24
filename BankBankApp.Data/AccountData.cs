using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public class AccountData : IAccountData
	{
		private readonly AppDbContext _context;
		public AccountData(AppDbContext context)
		{
			_context = context;
		}
		public Task<Account> Add(Account entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> Get(int id)
		{
			try
			{
				var account = await _context.Accounts.FindAsync(id);
				if (account == null)
				{
					throw new Exception("Account not found");
				}
				return account;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Account>> GetAll()
		{
			try
			{
				var accounts = await _context.Accounts.ToListAsync();
				if (accounts == null || accounts.Count() == 0)
				{
					throw new Exception("No accounts found");
				}
				return accounts;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Account> GetByAccountNumber(string accountNumber)
		{
			try
			{
				var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
				if (account == null)
				{
					throw new Exception("Account not found");
				}
				return account;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Account> GetByUserID(int userID)
		{
			try
			{
				var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == userID);
				if (account == null)
				{
					throw new Exception("Account not found");
				}
				return account;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Account> Update(Account entity)
		{
			try
			{
				_context.Accounts.Update(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
