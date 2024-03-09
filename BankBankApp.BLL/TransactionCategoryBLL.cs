using System;
using System.Collections.Generic;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using BankBankApp.DAL;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.BLL
{
	public class TransactionCategoryBLL : ITransactionCategory
	{
		private readonly ITransactionCategoryDAL _transactionCategoryDAL;
		public TransactionCategoryBLL()
		{
			_transactionCategoryDAL = new TransactionCategoryDAL();
		}

		public void Create(CreateTransactionCategoryDTO category)
		{
			if (string.IsNullOrEmpty(category.Name))
			{
				throw new ArgumentException("Name cannot be empty");
			}
			try
			{
				_transactionCategoryDAL.Create(new TransactionCategory
				{
					Name = category.Name
				});
			}
			catch (Exception ex)
			{
				throw new Exception("Error creating transaction category", ex);
			}
		}

		public void Delete(int id)
		{
			try
			{
				_transactionCategoryDAL.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error deleting transaction category: {ex}");
			}
		}

		public IEnumerable<TransactionCategoryDTO> GetAll()
		{
			List<TransactionCategoryDTO> categories = new List<TransactionCategoryDTO>();
			var result = _transactionCategoryDAL.Get();
			try
			{
				foreach (var category in result)
				{
					categories.Add(new TransactionCategoryDTO
					{
						TransactionCategoryID = category.TransactionCategoryID,
						Name = category.Name
					});
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error getting transaction categories", ex);
			}
			return categories;
		}

		public TransactionCategoryDTO GetById(int id)
		{
			try
			{
				var category = _transactionCategoryDAL.GetByID(id);
				if (category == null)
				{
					throw new ArgumentException("Category not found");
				}
				return new TransactionCategoryDTO
				{
					TransactionCategoryID = category.TransactionCategoryID,
					Name = category.Name
				};
			}
			catch (Exception e)
			{
				throw new Exception("Error getting transaction category", e);
			}
		}

		public TransactionCategoryDTO GetByName(string name)
		{
			var category = _transactionCategoryDAL.GetByName(name);
			if (category == null)
			{
				throw new ArgumentException("Category not found");
			}
			return new TransactionCategoryDTO
			{
				TransactionCategoryID = category.TransactionCategoryID,
				Name = category.Name
			};
		}

		public void Update(int id, CreateTransactionCategoryDTO category)
		{
			if (string.IsNullOrEmpty(category.Name))
			{
				throw new ArgumentException("Name cannot be empty");
			}
			try
			{
				_transactionCategoryDAL.Update(new TransactionCategory
				{
					Name = category.Name
				}, id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error updating transaction category", ex);
			}
		}
	}
}
