using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BO;

namespace BankBankApp.BLL.Interfaces
{
	public interface IUser
	{
		void Create(UserCreateDTO user);
		void Update(UserDTO user, int id);
		void Delete(int id);
		UserDTO GetByID(int id);
		UserDTO GetByUsername(string username);
		IEnumerable<UserDTO> GetAll();
		UserViewBO Login(string username, string password);
	}
}
