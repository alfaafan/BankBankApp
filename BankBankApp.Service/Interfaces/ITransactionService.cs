using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Interfaces
{
	public interface ITransactionService
	{
		Task<TransactionDTO> Deposit(DepositDTO transaction);
		Task<TransactionDTO> Withdraw(WithdrawDTO transaction);
		Task<TransactionDTO> Transfer(TransferDTO transaction);
		Task<TransactionDTO> Get(int id);
		Task<IEnumerable<TransactionDTO>> GetByAccount(int accountID);
		Task<IEnumerable<TransactionDTO>> GetAll();
		Task<bool> Delete(int id);
	}
}
