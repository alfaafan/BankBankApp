using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface ITransactionDAL : ICrud<Transaction>
    {
        IEnumerable<Transaction> GetByAccountID(int accountID);
        IEnumerable<Transaction> GetByUserID(int userID);
        void Transfer(Transaction transaction);
        void PayBill(Transaction transaction);
        void Deposit(Transaction transaction);
    }
}
