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
			ValidateUserForm(user);

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

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<UserDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public UserDTO GetByID(int id)
		{
			try
			{
				var user = _userDAL.GetByID(id);
				var userDTO = new UserDTO
				{
					Username = user.Username,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth
				};
				return userDTO;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public UserViewDTO GetByUsername(string username)
		{
			try
			{
				var user = _userDAL.GetByUsername(username);
				var userDTO = new UserViewDTO
				{
					UserID = user.UserID,
					Username = user.Username,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth,
					AccountNumber = user.AccountNumber,
					AccountID = user.AccountID,
					CardNumber = user.CardNumber,
					CardExpiryDate = user.CardExpiryDate,
					Balance = user.Balance,
					Status = user.Status,
					LastLoginDate = user.LastLoginDate
				};
				return userDTO;
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Error getting user", ex);
			}
		}

		public UserViewDTO Login(string username, string password)
		{
			ValidateLoginCredentials(username, password);

			try
			{
				var user = _userDAL.Login(username, Helper.GetHash(password));

				if (user == null)
				{
					throw new ArgumentException("User not found");
				}

				if (user.Password != Helper.GetHash(password))
				{
					throw new ArgumentException("Invalid password");
				}

				var userDTO = new UserViewDTO
				{
					UserID = user.UserID,
					Username = user.Username,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth,
					AccountNumber = user.AccountNumber,
					AccountID = user.AccountID,
					CardNumber = user.CardNumber,
					CardExpiryDate = user.CardExpiryDate,
					Balance = user.Balance,
					Status = user.Status,
					LastLoginDate = user.LastLoginDate
				};

				return userDTO;
			}
			catch (Exception e)
			{
				throw new ArgumentException("Error logging in", e);
			}
		}

		public void Update(UserUpdateDTO user)
		{
			try
			{
				var existingUser = _userDAL.GetByUsername(user.Username);
				var userToUpdate = new User
				{
					UserID = existingUser.UserID,
					Username = user.Username,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phone = user.Phone,
					DateOfBirth = user.DateOfBirth
				};

				_userDAL.Update(userToUpdate, userToUpdate.UserID);
			}
			catch (Exception)
			{

				throw;
			}
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

		public void ValidateUserForm(UserCreateDTO user)
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
