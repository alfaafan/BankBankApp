using System;
using System.Collections.Generic;
using System.Text;

namespace BankBankApp.DAL.Interfaces
{
    public interface ICrud<T>
    {
        void Create(T obj);
        IEnumerable<T> Get();
        T GetByID(int id);
        T Update(T obj, int id);
        void Delete(int id);
    }
}
