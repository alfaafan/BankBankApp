using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
    public interface IUser
    {
        void Create(UserCreateDTO user);
        void Update(UserDTO user);
        void Delete(UserDTO user);
        UserDTO GetByID(int id);
        UserDTO GetByUsername(string username);
        IEnumerable<UserDTO> GetAll();
        UserDTO Login(string username, string password);
    }
}
