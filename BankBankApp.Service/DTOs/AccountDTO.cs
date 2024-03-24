using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class AccountDTO
	{
		public int AccountId { get; set; }
		public int UserId { get; set; }
		public string? AccountNumber { get; set; }
		public int AccountTypeId { get; set; }
		public decimal Balance { get; set; }
		public string? Status { get; set; }
	}
}
