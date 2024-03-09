using System;

namespace BankBankApp.BO
{
    public class Account
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string AccountNumber { get; set; }
        public int AccountTypeID { get; set; }
        public decimal Balance { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? CreditLimit { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
