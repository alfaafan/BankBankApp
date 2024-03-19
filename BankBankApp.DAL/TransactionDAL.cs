using System;
using System.Collections.Generic;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using System.Data.SqlClient;
using Dapper;

namespace BankBankApp.DAL
{
	public class TransactionDAL : ITransactionDAL
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Create(Transaction obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Deposit(DepositBO transaction)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var sql = "[Transactions].[sp_DepositTransaction]";
				var param = new
				{
					AccountID = transaction.AccountID,
					Amount = transaction.Amount
				};

				try
				{
					connection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public IEnumerable<Transaction> Get()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Transaction> GetByAccountID(int accountID)
		{
			throw new NotImplementedException();
		}

		public Transaction GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public void PayBill(Transaction transaction)
		{
			throw new NotImplementedException();
		}

		public void Transfer(Transaction transaction)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString
				()))
			{
				connection.Open();
				var sql = "[Transactions].[TransferTransaction]";
				var param = new
				{
					SourceAccountID = transaction.SourceAccountID,
					ReceiverAccountID = transaction.ReceiverAccountID,
					Amount = transaction.Amount,
					Description = transaction.Description,
				};

				try
				{
					connection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public void Update(Transaction obj, int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Transaction> GetByUserID(int userID)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var sql = "Select * From dbo.UserTransactionHistory WHERE UserID = @UserID ORDER BY TransactionDate DESC";
				var param = new { UserID = userID };

				try
				{
					return connection.Query<Transaction>(sql, param);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public void Withdraw(WithdrawBO transaction)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var sql = "[Transactions].[WithdrawalTransaction]";
				var param = new
				{
					AccountID = transaction.AccountID,
					Amount = transaction.Amount,
					Description = transaction.Description,
				};

				try
				{
					connection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
	}
}
