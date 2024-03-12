using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
	public interface ITransaction
	{
		void Transfer(TransferDTO transfer);
		IEnumerable<TransactionHistoryDTO> GetTransactionHistory(int userID);
	}
}
