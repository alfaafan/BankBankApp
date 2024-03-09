using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;
using BankBankApp.DAL;
using BankBankApp.DAL.Interfaces;

namespace BankBankApp.BLL
{
	public class UserBLL : IUser
	{
		private readonly IUserDAL _userDAL;
		public UserBLL()
		{
			_userDAL = new UserDAL();
		}
		public void Create(UserCreateDTO user)
		{
			if (string.IsNullOrEmpty(user.Username))
			{
				throw new ArgumentException("Username is required");
			}
			if (string.IsNullOrEmpty(user.Password))
			{
				throw new ArgumentException("Password is required");
			}
			if (string.IsNullOrEmpty(user.Email))
			{
				throw new ArgumentException("Email is required");
			}
			if (string.IsNullOrEmpty(user.FirstName))
			{
				throw new ArgumentException("First name is required");
			}
			if (string.IsNullOrEmpty(user.LastName))
			{
				throw new ArgumentException("Last name is required");
			}
			if (string.IsNullOrEmpty(user.Phone))
			{
				throw new ArgumentException("Phone is required");
			}
			if (user.DateOfBirth == DateTime.MinValue)
			{
				throw new ArgumentException("Date of birth is required");
			}
			if (user.Password != user.RepeatPassword)
			{
				throw new ArgumentException("Passwords do not match");
			}
			try
			{
				var newUser = new User
				{
					Username = user.Username,
					Password = Helper.GetHash(user.Password),
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth
				};

				_userDAL.Create(newUser);
			}
			catch (Exception e)
			{
				throw new ArgumentException("Error creating user", e);
			}
		}

		public void Delete(UserDTO user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<UserDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public UserDTO GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public UserDTO GetByUsername(string username)
		{
			throw new NotImplementedException();
		}

		public UserDTO Login(string username, string password)
		{
			ValidateLoginCredentials(username, password);

			try
			{
				var user = _userDAL.Login(username, Helper.GetHash(password));
				var userBO = new User
				{
					UserID = user.UserID,
					Username = user.Username,
					Email = user.Email,
					Password = user.Password,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth,
					LastLoginDate = user.LastLoginDate
				};

				if (user == null)
				{
					throw new ArgumentException("User not found");
				}

				if (user.Password != Helper.GetHash(password))
				{
					throw new ArgumentException("Invalid password");
				}

				UpdateLastLogin(user);

				return new UserDTO
				{
					Username = user.Username,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth
				};
			}
			catch (Exception e)
			{
				throw new Exception("Error logging in", e);
			}
		}

		public void Update(UserDTO user)
		{
			throw new NotImplementedException();
		}

		private void ValidateLoginCredentials(string username, string password)
		{
			if (string.IsNullOrEmpty(username))
			{
				throw new ArgumentException("Username is required");
			}
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("Password is required");
			}
		}

		private void UpdateLastLogin(UserViewBO user)
		{
			User userToUpdate = new User
			{
				UserID = user.UserID,
				Username = user.Username,
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Phone = user.Phone,
				DateOfBirth = user.DateOfBirth,
				LastLoginDate = DateTime.Now
			};
			_userDAL.Update(userToUpdate, user.UserID);

		}
	}
}
