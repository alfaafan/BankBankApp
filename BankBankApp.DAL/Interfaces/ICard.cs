using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface ICard : ICrud<Card>
    {
        Card GetByCardNumber(string cardNumber);
    }
}
