using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class CardDTO
	{
		public int CardId { get; set; }
		public string CardNumber { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string Status { get; set; }
		public int UserId { get; set; }
	}
}
