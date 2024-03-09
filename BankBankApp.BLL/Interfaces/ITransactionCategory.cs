using System.Collections.Generic;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
    public interface ITransactionCategory
    {
        IEnumerable<TransactionCategoryDTO> GetAll();
        TransactionCategoryDTO GetByName(string name);
        TransactionCategoryDTO GetById(int id);
        void Create(CreateTransactionCategoryDTO category);
        void Update(int id, CreateTransactionCategoryDTO category);
        void Delete(int id);
    }
}
