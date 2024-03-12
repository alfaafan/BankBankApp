using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BO
{
	public class UserRegistration
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string AccountNumber { get; set; }
		public string CardNumber { get; set; }
	}
}
