using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface ITransactionCategoryDAL : ICrud<TransactionCategory>
    {
        TransactionCategory GetByName(string name);
    }
}
