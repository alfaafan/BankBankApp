using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
	public class BillDTO
	{
		public int BillID { get; set; }
		public string BillName { get; set; }
		public decimal Amount { get; set; }
		public DateTime DueDate { get; set; }
		public string Status { get; set; }
		public int UserID { get; set; }
	}
}
