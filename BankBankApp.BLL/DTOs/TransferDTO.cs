using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
	public class TransferDTO
	{
		public string SourceAccountNumber{ get; set; }
		public string ReceiverAccountNumber { get; set;}
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}
