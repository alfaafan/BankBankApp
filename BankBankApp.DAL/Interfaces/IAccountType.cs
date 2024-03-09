using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IAccountType : ICrud<AccountType>
    {
        AccountType GetByAccountTypeName(string accountTypeName);
    }
}
