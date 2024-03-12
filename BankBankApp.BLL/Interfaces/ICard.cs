using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;

namespace BankBankApp.BLL.Interfaces
{
	public interface ICard
	{
		void Create(Card card);
		void Update(Card card, int id);
		void Delete(int id);
		Card GetByID(int id);
		Card GetByCardNumber(string cardNumber);
		IEnumerable<Card> GetAll();
		Card GetByUserID(int userID);
	}
}
