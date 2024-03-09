using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BankBankApp.DAL
{
    public class TransactionCategoryDAL : ITransactionCategoryDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void Create(TransactionCategory category)
        {
            //use dapper to create
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Transactions.TransactionCategories (Name) VALUES (@Name)";
                var param = new
                {
                    Name = category.Name
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error creating category");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "DELETE FROM Transactions.TransactionCategories WHERE TransactionCategoryID = @TransactionCategoryID";
                var param = new
                {
                    TransactionCategoryID = id
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error deleting category");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                    throw;
                }
            }
        }

        public IEnumerable<TransactionCategory> Get()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "SELECT * FROM Transactions.TransactionCategories";
                return connection.Query<TransactionCategory>(sql);
            }
        }

        public TransactionCategory GetByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "SELECT * FROM Transactions.TransactionCategories WHERE TransactionCategoryID = @TransactionCategoryID";
                var param = new
                {
                    TransactionCategoryID = id
                };
                return connection.QueryFirstOrDefault<TransactionCategory>(sql, param);
            }
        }

        public TransactionCategory GetByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "SELECT * FROM Transactions.TransactionCategories WHERE Name = @Name";
                var param = new
                {
                    Name = name
                };
                return connection.QueryFirstOrDefault<TransactionCategory>(sql, param);
            }
        }

        public TransactionCategory Update(TransactionCategory category, int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "UPDATE Transactions.TransactionCategories SET Name = @Name WHERE TransactionCategoryID = @TransactionCategoryID";
                var param = new
                {
                    Name = category.Name,
                    TransactionCategoryID = id
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error updating category");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
                return category;
            }
        }
    }
}
