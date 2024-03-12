using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using BankBankApp.DAL;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.BLL
{
	public class CardBLL : ICard
	{
		private readonly ICardDAL _cardDAL;
		public CardBLL()
		{
			_cardDAL = new CardDAL();
		}
		public void Create(Card card)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Card> GetAll()
		{
			throw new NotImplementedException();
		}

		public Card GetByCardNumber(string cardNumber)
		{
			throw new NotImplementedException();
		}

		public Card GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public Card GetByUserID(int userID)
		{
			try
			{
				return _cardDAL.GetByUserID(userID);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void Update(Card card, int id)
		{
			throw new NotImplementedException();
		}
	}
}
