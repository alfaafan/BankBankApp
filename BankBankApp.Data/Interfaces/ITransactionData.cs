using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Domain;

namespace BankBankApp.Data.Interfaces
{
	public interface ITransactionData : ICrudData<Transaction>
	{
		public Task<Transaction> Transfer(Transaction transaction);
		public Task<Transaction> Deposit(Transaction transaction);
		public Task<Transaction> Withdraw(Transaction transaction);
		public Task<Transaction> PayBill(Transaction transaction);
		public Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int accountId);
		public Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userId);
	}
}
