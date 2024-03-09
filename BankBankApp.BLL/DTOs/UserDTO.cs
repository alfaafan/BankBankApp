using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BLL.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
