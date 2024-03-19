using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
	public interface ITransaction
	{
		void Transfer(TransferDTO transfer);
		void Withdraw(WithdrawDTO transaction);
		void Deposit(DepositDTO transaction);
		IEnumerable<TransactionHistoryDTO> GetTransactionHistory(int userID);
	}
}
