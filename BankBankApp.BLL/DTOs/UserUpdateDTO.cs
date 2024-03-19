using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
	public class UserUpdateDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
