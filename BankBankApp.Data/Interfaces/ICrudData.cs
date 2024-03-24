using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Data.Interfaces
{
	public interface ICrudData<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
		Task<T> Add(T entity);
		Task<T> Update(T entity);
		Task<bool> Delete(int id);
	}
}
