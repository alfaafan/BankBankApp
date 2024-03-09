using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IBiller : ICrud<Biller>
    {
        Biller GetByBillerAccountNumber(string billerAccountNumber);
    }
}
