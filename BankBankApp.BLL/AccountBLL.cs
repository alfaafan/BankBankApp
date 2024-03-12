using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.DAL.Interfaces;
using BankBankApp.DAL;

namespace BankBankApp.BLL
{
	public class AccountBLL : IAccount
	{
		private readonly IAccountDAL _accountDAL;
		public AccountBLL()
		{
			_accountDAL = new AccountDAL();
		}
		public AccountDTO GetByAccountNumber(string accountNumber)
		{

			try
			{
				var account = _accountDAL.GetByAccountNumber(accountNumber);
				var accountDTO = new AccountDTO
				{
					AccountNumber = account.AccountNumber,
					Balance = account.Balance
				};
				return accountDTO;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
