using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Data.Helpers;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public class CardData : ICardData
	{
		private readonly AppDbContext _context;
		public CardData(AppDbContext context)
		{
			_context = context;
		}
		public async Task<Card> Add(Card entity)
		{
			try
			{
				var card = new Card
				{
					CardNumber = Helper.GenerateCardNumber(),
					ExpirationDate = entity.ExpirationDate,
					Status = entity.Status,
					UserId = entity.UserId
				};
				await _context.Cards.AddAsync(card);
				await _context.SaveChangesAsync();
				return card;
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

		public async Task<Card> Get(int id)
		{
			try
			{
				var card = await _context.Cards.FindAsync(id);
				if (card == null)
				{
					throw new Exception("Card not found");
				}
				return card;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Card>> GetAll()
		{
			try
			{
				var cards = await _context.Cards.ToListAsync();
				if (cards == null || cards.Count() == 0)
				{
					throw new Exception("No cards found");
				}
				return cards;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Card> GetByCardNumber(string cardNumber)
		{
			try
			{
				var card = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
				if (card == null)
				{
					throw new Exception("Card not found");
				}
				return card;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Card> GetByUserID(int userID)
		{
			try
			{
				var card = await _context.Cards.FirstOrDefaultAsync(c => c.UserId == userID);
				if (card == null)
				{
					throw new Exception("Card not found");
				}
				return card;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Card> Update(Card entity)
		{
			try
			{
				var card = await _context.Cards.FindAsync(entity.CardId);
				if (card == null)
				{
					throw new Exception("Card not found");
				}
				card.Status = entity.Status;
				await _context.SaveChangesAsync();
				return card;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
