using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BO
{
	public class User
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime RegistrationDate { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public string AccountNumber { get; set; }
		public string CardNumber { get; set; }
	}
}
