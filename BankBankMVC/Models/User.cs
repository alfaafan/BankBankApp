using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankBankApp.MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}