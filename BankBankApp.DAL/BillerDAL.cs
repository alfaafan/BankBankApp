using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.DAL
{
    public class BillerDAL : IBiller
    {
        public void Create(Biller obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Biller> Get()
        {
            throw new NotImplementedException();
        }

        public Biller GetByBillerAccountNumber(string billerAccountNumber)
        {
            throw new NotImplementedException();
        }

        public Biller GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Biller Update(Biller obj, int id)
        {
            throw new NotImplementedException();
        }
    }
}
