using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
    public interface IRole : ICrud<Role>
    {
        void AddUserToRole(string username, int roleID);
    }
}
