using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
	public interface IUserDAL : ICrud<User>
	{
		UserViewBO GetByUsername(string username);
		UserViewBO Login(string username, string password);
	}
}
