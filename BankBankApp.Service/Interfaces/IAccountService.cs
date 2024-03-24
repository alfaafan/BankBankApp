using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Interfaces
{
	public interface IAccountService
	{
		Task<AccountDTO> GetAccountByAccountNumber(string accountNumber);
		Task<AccountDTO> GetAccountById(int id);
		Task<IEnumerable<AccountDTO>> GetAccounts();
		Task<AccountDTO> UpdateAccount(AccountDTO account);
	}
}
