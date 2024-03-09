using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using BankBankApp.DAL;

namespace BankBankApp.BLL
{
    public class CardTypeBLL : ICardType
    {
        private readonly CardTypeDAL _cardTypeDAL;
        public CardTypeBLL()
        {
            _cardTypeDAL = new CardTypeDAL();
        }
        public void Create(CardTypeDTO obj)
        {
            if (string.IsNullOrEmpty(obj.Type))
            {
                throw new ArgumentException("Type cannot be empty");
            }

            try
            {
                var cardType = new CardType()
                {
                    Type = obj.Type
                };
                _cardTypeDAL.Create(cardType);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _cardTypeDAL.Delete(id);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e.Message);
            }
        }

        public IEnumerable<CardTypeDTO> GetAll()
        {
            List<CardTypeDTO> cardTypes = new List<CardTypeDTO>();
            try
            {
                var cardTypeList = _cardTypeDAL.Get();
                foreach (var cardType in cardTypeList)
                {
                    cardTypes.Add(new CardTypeDTO()
                    {
                        Type = cardType.Type
                    });
                }
                return cardTypes;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e.Message);
            }
        }

        public CardTypeDTO GetByCardTypeName(string cardTypeName)
        {
            try
            {
                var cardType = _cardTypeDAL.GetByCardTypeName(cardTypeName);
                return new CardTypeDTO()
                {
                    Type = cardType.Type
                };
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e.Message);
            }
        }

        public void Update(CardTypeDTO obj, int id)
        {
            if (string.IsNullOrEmpty(obj.Type))
            {
                throw new ArgumentException("Type cannot be empty");
            }

            try
            {
                var cardType = new CardType()
                {
                    Type = obj.Type
                };
                _cardTypeDAL.Update(cardType, id);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: " + e.Message);
            }
        }
    }
}
