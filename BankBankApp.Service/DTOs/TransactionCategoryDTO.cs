using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class TransactionCategoryDTO
	{
		public int TransactionCategoryID { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}
