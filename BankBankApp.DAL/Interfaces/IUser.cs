using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IUserDAL : ICrud<User>
    {
        User GetByUsername(string username);
        User Login(string username, string password);
    }
}
