﻿using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IBill : ICrud<Bill>
    {
        Bill GetByBillNumber(string billNumber);
    }
}
