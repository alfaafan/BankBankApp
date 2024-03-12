using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
	public interface IAccount
	{
		AccountDTO GetByAccountNumber(string accountNumber);
	}
}
