using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.DAL.Interfaces
{
	public interface ICardDAL : ICrud<Card>
	{
		Card GetByCardNumber(string cardNumber);
		Card GetByUserID(int userID);
	}
}
