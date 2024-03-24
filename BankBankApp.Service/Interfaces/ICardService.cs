using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Interfaces
{
	public interface ICardService
	{
		Task<CardDTO> Add(CardDTO entity);
		Task<IEnumerable<CardDTO>> GetAll();
		Task<CardDTO> Get(int id);
		Task<CardDTO> GetByCardNumber(string cardNumber);
		Task<CardDTO> Update(CardDTO entity);
		Task<bool> Delete(int id);
	}
}
