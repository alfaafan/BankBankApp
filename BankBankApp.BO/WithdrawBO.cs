using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BO
{
	public class WithdrawBO
	{
		public int AccountID { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}
