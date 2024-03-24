using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;

namespace BankBankApp.Service
{
	public class CardService : ICardService
	{
		private readonly ICardData _cardData;
		private readonly IMapper _mapper;
		public CardService(ICardData cardData, IMapper mapper)
		{
			_cardData = cardData;
			_mapper = mapper;
		}
		public async Task<CardDTO> Add(CardDTO entity)
		{
			try
			{
				var card = _mapper.Map<CardDTO, Card>(entity);
				var result = await _cardData.Add(card);
				return _mapper.Map<Card, CardDTO>(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<CardDTO> Get(int id)
		{
			try
			{
				var card = await _cardData.Get(id);
				return _mapper.Map<Card, CardDTO>(card);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<CardDTO>> GetAll()
		{
			try
			{
				var cards = await _cardData.GetAll();
				return _mapper.Map<IEnumerable<Card>, IEnumerable<CardDTO>>(cards);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<CardDTO> GetByCardNumber(string cardNumber)
		{
			try
			{
				var card = await _cardData.GetByCardNumber(cardNumber);
				return _mapper.Map<Card, CardDTO>(card);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<CardDTO> Update(CardDTO entity)
		{
			try
			{
				var card = _mapper.Map<CardDTO, Card>(entity);
				var result = await _cardData.Update(card);
				return _mapper.Map<Card, CardDTO>(result);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
