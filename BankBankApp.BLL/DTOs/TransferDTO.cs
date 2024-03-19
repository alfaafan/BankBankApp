using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
	public class TransferDTO
	{
		public string SourceAccountNumber{ get; set; }
		[Required]
		public string ReceiverAccountNumber { get; set;}
		[Required]
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}
