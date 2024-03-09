using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
    public interface ICardType
    {
        IEnumerable<CardTypeDTO> GetAll();
        CardTypeDTO GetByCardTypeName(string cardTypeName);
        void Create(CardTypeDTO obj);
        void Update(CardTypeDTO obj, int id);
        void Delete(int id);
    }
}
