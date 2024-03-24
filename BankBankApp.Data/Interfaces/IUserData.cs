using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Domain;

namespace BankBankApp.Data.Interfaces
{
	public interface IUserData : ICrudData<User>
	{
		Task<User> GetByUsername(string username);
		Task<User> GetWithAccountAndCard(int id);
		Task<User> Login(string username, string password);
	}
}
