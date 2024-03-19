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
		void Update(UserUpdateDTO user);
		void Delete(int id);
		UserDTO GetByID(int id);
		UserViewDTO GetByUsername(string username);
		IEnumerable<UserDTO> GetAll();
		UserViewDTO Login(string username, string password);
	}
}
