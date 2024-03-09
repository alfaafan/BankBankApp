using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.BO
{
    public class Bill
    {
        public int BillID { get; set; }
        public int BillerID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
