using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class TransactionCreateDTO
	{
		public int TransactionCategoryID { get; set; }
		public int SourceAccountID { get; set; }
		public int? ReceiverAccountID { get; set; }
		public int? BillID { get; set; }
		public decimal Amount { get; set; }
		public string? Description { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.Now;
		public string Status { get; set; } = "Pending";
	}
}
