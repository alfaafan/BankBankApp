using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Domain;

namespace BankBankApp.Data.Interfaces
{
	public interface ICardData : ICrudData<Card>
	{
		Task<Card> GetByCardNumber(string cardNumber);
		Task<Card> GetByUserID(int userID);
	}
}
