using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;

namespace BankBankApp.DAL
{
	public class CardTypeDAL : ICardType
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Create(CardType obj)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "INSERT INTO Users.CardTypes (Type) VALUES (@Type)";
				var param = new
				{
					Type = obj.Type
				};

				try
				{
					int result = connection.Execute(sql, param);
					if (result != 1)
					{
						throw new Exception("Error creating card type");
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
				var sql = "DELETE FROM Users.CardTypes WHERE CardTypeID = @CardTypeID";
				var param = new
				{
					CardTypeID = id
				};

				try
				{
					int result = connection.Execute(sql, param);
					if (result != 1)
					{
						throw new Exception("Error deleting card type");
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

		public IEnumerable<CardType> Get()
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.CardTypes";
				try
				{
					return connection.Query<CardType>(sql);
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

		public CardType GetByCardTypeName(string cardTypeName)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.CardTypes WHERE Type = @Type";
				var param = new
				{
					Type = cardTypeName
				};
				try
				{
					return connection.QueryFirstOrDefault<CardType>(sql, param);
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

		public CardType GetByID(int id)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.CardTypes WHERE CardTypeID = @CardTypeID";
				var param = new
				{
					CardTypeID = id
				};
				try
				{
					return connection.QueryFirstOrDefault<CardType>(sql, param);
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

		public void Update(CardType obj, int id)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "UPDATE Users.CardTypes SET Type = @Type WHERE CardTypeID = @CardTypeID";
				var param = new
				{
					Type = obj.Type,
					CardTypeID = id
				};
				try
				{
					int result = connection.Execute(sql, param);
					if (result != 1)
					{
						throw new Exception("Error updating card type");
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
	}
}
