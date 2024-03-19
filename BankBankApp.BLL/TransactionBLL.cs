using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using BankBankApp.DAL;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.BLL
{
	public class TransactionBLL : ITransaction
	{
		private readonly ITransactionDAL _transactionDAL;
		private readonly IAccountDAL _accountDAL;
		public TransactionBLL()
		{
			_transactionDAL = new TransactionDAL();
			_accountDAL = new AccountDAL();
		}

		public void Deposit(DepositDTO transaction)
		{
			var deposit = new DepositBO
			{
				AccountID = transaction.AccountID,
				Amount = transaction.Amount
			};

			try
			{
				_transactionDAL.Deposit(deposit);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IEnumerable<TransactionHistoryDTO> GetTransactionHistory(int userID)
		{
			var transactionHistory = new List<TransactionHistoryDTO>();
			try
			{
				var transactions = _transactionDAL.GetByUserID(userID);
				foreach (var transaction in transactions)
				{
					transactionHistory.Add(new TransactionHistoryDTO
					{
						TransactionDate = transaction.TransactionDate,
						TransactionCategory = transaction.TransactionCategory,
						Amount = transaction.Amount,
						ReceiverAccountNumber = transaction.ReceiverAccountNumber
					});
				}
				return transactionHistory;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void Transfer(TransferDTO transfer)
		{
			var sourceAccount = _accountDAL.GetByAccountNumber(transfer.SourceAccountNumber);
			var receiverAccount = _accountDAL.GetByAccountNumber(transfer.ReceiverAccountNumber);
			var sourceAccountID = sourceAccount.AccountID;
			var receiverAccountID = receiverAccount.AccountID;

			var transaction = new Transaction
			{
				SourceAccountID = sourceAccountID,
				ReceiverAccountID = receiverAccountID,
				Amount = transfer.Amount,
				Description = transfer.Description,
			};

			try
			{
				_transactionDAL.Transfer(transaction);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void Withdraw(WithdrawDTO transaction)
		{
			var withdraw = new WithdrawBO
			{
				AccountID = transaction.AccountID,
				Amount = transaction.Amount,
				Description = transaction.Description
			};

			try
			{
				_transactionDAL.Withdraw(withdraw);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
