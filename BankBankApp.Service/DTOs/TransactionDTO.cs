using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class TransactionDTO
	{
		public int TransactionID { get; set; }
		public int TransactionCategoryID { get; set; }
		public required string TransactionCategory { get; set; }
		public int UserID { get; set; }
		public int SourceAccountID { get; set; }
		public int? ReceiverAccountID { get; set; }
		public string ReceiverAccountNumber { get; set; } = null!;
		public int? BillID { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; } = string.Empty;
		public DateTime TransactionDate { get; set; }
		public string Status { get; set; } = "Pending";
	}
}
