using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Service.DTOs
{
	public class UserWithAccountAndCardDTO
	{
		public int UserId { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public DateOnly DateOfBirth { get; set; }
		public DateTime RegistrationDate { get; set; }
		public DateTime LastLoginDate { get; set; }

		public AccountDTO? Account { get; set; }
		public CardDTO? Card { get; set; }
	}
}
