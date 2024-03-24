using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Domain;

namespace BankBankApp.Data.Interfaces
{
	public interface IAccountData : ICrudData<Account>
	{
		Task<Account> GetByAccountNumber(string accountNumber);
		Task<Account> GetByUserID(int userID);
	}
}
