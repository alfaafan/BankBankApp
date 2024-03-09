using System;
using System.Collections.Generic;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.DAL
{
    public class TransactionDAL : ITransaction
    {
        public void Create(Transaction obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetByAccountID(int accountID)
        {
            throw new NotImplementedException();
        }

        public Transaction GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Transaction Update(Transaction obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
