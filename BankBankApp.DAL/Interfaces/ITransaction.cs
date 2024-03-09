using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface ITransaction : ICrud<Transaction>
    {
        IEnumerable<Transaction> GetByAccountID(int accountID);
    }
}
