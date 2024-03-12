using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;

namespace BankBankApp.DAL
{
	public class CardDAL : ICardDAL
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Create(Card obj)
		{
			using (var connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var query = "INSERT INTO Card (UserID, CardNumber, CardTypeID) VALUES (@UserID, @CardNumber, @CardTypeID)";
				var parameters = new { UserID = obj.UserID, CardNumber = obj.CardNumber, CardTypeID = obj.CardTypeID };
				try
				{
					connection.Execute(query, parameters);
				}
				catch (Exception e)
				{
					throw new ArgumentException("Error: " + e.Message);
				}
			}
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Card> Get()
		{
			throw new NotImplementedException();
		}

		public Card GetByCardNumber(string cardNumber)
		{
			using (var connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var query = "SELECT * FROM Card WHERE CardNumber = @CardNumber";
				var parameters = new { CardNumber = cardNumber };
				try
				{
					return connection.QueryFirstOrDefault<Card>(query, parameters);
				}
				catch (Exception e)
				{
					throw new ArgumentException("Error: " + e.Message);
				}
			}
		}

		public Card GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Card obj, int id)
		{
			throw new NotImplementedException();
		}

		public Card GetByUserID(int userID)
		{
			using (var connection = new SqlConnection(GetConnectionString()))
			{
				connection.Open();
				var query = "SELECT * FROM Users.Cards WHERE UserID = @UserID";
				var parameters = new { UserID = userID };
				try
				{
					return connection.QueryFirstOrDefault<Card>(query, parameters);
				}
				catch (Exception e)
				{
					throw new ArgumentException("Error: " + e.Message);
				}
			}
		}
	}
}
