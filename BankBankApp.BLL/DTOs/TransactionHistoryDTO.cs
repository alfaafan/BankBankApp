using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
	public class TransactionHistoryDTO
	{
		public DateTime TransactionDate { get; set; }
		public string TransactionCategory { get; set; }
		public decimal Amount { get; set; }
		public string ReceiverAccountNumber { get; set; }

	}
}
