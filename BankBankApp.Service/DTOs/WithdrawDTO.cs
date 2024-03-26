using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class WithdrawDTO
	{
		public int SourceAccountID { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
