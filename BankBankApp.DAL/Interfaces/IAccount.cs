﻿using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IAccountDAL : ICrud<Account>
    {
        Account GetByAccountNumber(string accountNumber);
    }
}
