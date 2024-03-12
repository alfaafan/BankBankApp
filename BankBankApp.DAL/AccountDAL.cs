using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;

namespace BankBankApp.DAL
{
	public class AccountDAL : IAccountDAL
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Create(Account obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Account> Get()
		{
			throw new NotImplementedException();
		}

		public Account GetByAccountNumber(string accountNumber)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var sql = "Select * From Users.Accounts WHERE AccountNumber = @AccountNumber";
				var param = new { AccountNumber = accountNumber };

				try
				{
					return connection.QueryFirstOrDefault<Account>(sql, param);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public Account GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Account obj, int id)
		{
			throw new NotImplementedException();
		}
	}
}
