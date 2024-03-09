using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BO
{
    public class Card
    {
        public int CardID { get; set; }
        public int UserID { get; set; }
        public string CardNumber { get; set; }
        public int CardTypeID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
    }
}
