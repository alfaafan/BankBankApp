using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Data.Helpers;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public class UserData : IUserData
	{
		private readonly AppDbContext _context;
		public UserData(AppDbContext context)
		{
			_context = context;
		}
		public async Task<User> Add(User entity)
		{
			try
			{
				var parameters = new SqlParameter[]
				{
					new SqlParameter("@Username", entity.Username),
					new SqlParameter("@Email", entity.Email),
					new SqlParameter("@Password", Helper.HashPassword(entity.Password)),
					new SqlParameter("@FirstName", entity.FirstName),
					new SqlParameter("@LastName", entity.LastName),
					new SqlParameter("@Phone", entity.Phone),
					new SqlParameter("@DateOfBirth", entity.DateOfBirth),
					new SqlParameter("@AccountNumber", Helper.GenerateAccountNumber()),
					new SqlParameter("@CardNumber", Helper.GenerateCardNumber())
				};

				var result = await _context.Database.ExecuteSqlRawAsync("EXEC Users.RegisterUser @Username, @Email, @Password, @FirstName, @LastName, @Phone, @DateOfBirth, @AccountNumber, @CardNumber", parameters);
				if (result == 0)
				{
					throw new Exception("User not created");
				}
				var createdUser = await GetByUsername(entity.Username);
				return createdUser;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var user = await _context.Users.FindAsync(id);
				if (user == null)
				{
					throw new Exception("User not found");
				}
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> Get(int id)
		{
			try
			{
				var user = await _context.Users.FindAsync(id);
				if (user == null)
				{
					throw new Exception("No user found");
				}
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			try
			{
				var users = await _context.Users.ToListAsync();
				if (users == null || users.Count == 0)
				{
					throw new Exception("No users found");
				}
				return users;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> GetByUsername(string username)
		{
			try
			{
				var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
				if (user == null)
				{
					throw new Exception("User not found");
				}
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> GetWithAccountAndCard(int id)
		{
			try
			{
				var user = await _context.Users.Include(u => u.Accounts).Include(u => u.Cards).FirstOrDefaultAsync(u => u.UserId == id);
				if (user == null)
				{
					throw new Exception("User not found");
				}
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> Login(string username, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				{
					throw new Exception("Username and password are required");
				}
				var user = await _context.Users.Include(u => u.Accounts).Include(u => u.Cards).FirstOrDefaultAsync(u => u.Username == username);
				if (user == null || !Helper.VerifyPassword(password, user.Password))
				{
					throw new Exception("Invalid username or password");
				}
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> Update(User entity)
		{
			try
			{
				var user = await _context.Users.FindAsync(entity.UserId);
				if (user == null)
				{
					throw new Exception("User not found");
				}
				user.Username = entity.Username;
				user.Email = entity.Email;
				user.FirstName = entity.FirstName;
				user.LastName = entity.LastName;
				user.Phone = entity.Phone;
				user.DateOfBirth = entity.DateOfBirth;
				await _context.SaveChangesAsync();
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
