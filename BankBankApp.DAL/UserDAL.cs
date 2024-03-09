using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;

namespace BankBankApp.DAL
{
	public class UserDAL : IUserDAL
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}

		public void Create(User obj)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "[Users].[RegisterUser]";
				var param = new
				{
					Username = obj.Username,
					Email = obj.Email,
					Password = obj.Password,
					FirstName = obj.FirstName,
					LastName = obj.LastName,
					Phone = obj.Phone,
					DateOfBirth = obj.DateOfBirth,
				};

				try
				{
					int result = connection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);
					if (result != 2)
					{
						throw new Exception("Error creating user: Cannot execute Register USer procedure");
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
				var sql = "DELETE FROM Users.Users WHERE UserID = @UserID";
				var param = new
				{
					UserID = id
				};

				try
				{
					int result = connection.Execute(sql, param);
					if (result != 1)
					{
						throw new Exception("Error deleting user");
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

		public IEnumerable<User> Get()
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.Users";
				return connection.Query<User>(sql);
			}
		}

		public User GetByID(int id)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.Users WHERE UserID = @UserID";
				var param = new
				{
					UserID = id
				};
				return connection.QueryFirstOrDefault<User>(sql, param);
			}
		}

		public User GetByUsername(string username)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.Users WHERE Username = @Username";
				var param = new
				{
					Username = username
				};
				return connection.QueryFirstOrDefault<User>(sql, param);
			}
		}

		public User Update(User obj, int id)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "UPDATE Users.Users SET Username = @Username, Email = @Email, Password = @Password, FirstName = @FirstName, LastName = @LastName, Phone = @Phone, DateOfBirth = @DateOfBirth, RegistrationDate = @RegistrationDate, LastLoginDate = @LastLoginDate WHERE UserID = @UserID";
				var param = new
				{
					Username = obj.Username,
					Email = obj.Email,
					Password = obj.Password,
					FirstName = obj.FirstName,
					LastName = obj.LastName,
					Phone = obj.Phone,
					DateOfBirth = obj.DateOfBirth,
					RegistrationDate = obj.RegistrationDate,
					LastLoginDate = obj.LastLoginDate,
					UserID = id
				};

				try
				{
					int result = connection.Execute(sql, param);
					if (result != 1)
					{
						throw new Exception("Error updating user");
					}
					return GetByID(id);
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

		public UserViewBO Login(string username, string password)
		{
			using (SqlConnection connection = new SqlConnection(GetConnectionString()))
			{
				var sql = "SELECT * FROM Users.UserView WHERE Username = @Username AND Password = @Password";
				var param = new
				{
					Username = username,
					Password = password
				};
				try
				{
					var result = connection.QueryFirstOrDefault<UserViewBO>(sql, param);
					if (result == null)
					{
						throw new ArgumentException("User not found");
					}
					return result;
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
