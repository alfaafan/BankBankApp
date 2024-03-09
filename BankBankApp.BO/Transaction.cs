using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BankBankApp.BO
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TransactionCategoryID { get; set; }
        public int SourceAccountID { get; set; }
        public int? ReceiverAccountID { get; set; }
        public int? BillID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
