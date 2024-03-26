using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public class RoleData : IRoleData
	{
		private readonly AppDbContext _context;
		public RoleData(AppDbContext context)
		{
			_context = context;
		}
		public async Task<Role> Add(Role entity)
		{
			try
			{
				var role = await _context.Roles.AddAsync(entity);
				await _context.SaveChangesAsync();
				return role.Entity;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public Task<Task> AddUserToRole(User user, Role role)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Role> Get(int id)
		{
			try
			{
				var role = await _context.Roles.FindAsync(id);
				if (role == null)
				{
					throw new Exception("Role not found");
				}
				return role;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<IEnumerable<Role>> GetAll()
		{
			try
			{
				var roles = await _context.Roles.ToListAsync();
				if (roles == null || roles.Count() == 0)
				{
					throw new Exception("No roles found");
				}
				return roles;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<Role> GetRoleByName(string name)
		{
			try
			{
				var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == name);
				if (role == null)
				{
					throw new Exception("Role not found");
				}
				return role;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<IEnumerable<Role>> GetUserRolesByUsername(string username)
		{
			try
			{
				var roles = await _context.Roles.Where(r => r.Usernames.Any(u => u.Username == username)).ToListAsync();
				if (roles == null || roles.Count() == 0)
				{
					throw new Exception("No roles found");
				}
				return roles;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null)
				{
					throw new Exception(ex.InnerException.Message);
				}
				else
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public Task<Task> RemoveUserFromRole(User user, Role role)
		{
			throw new NotImplementedException();
		}

		public Task<Role> Update(Role entity)
		{
			throw new NotImplementedException();
		}
	}
}
