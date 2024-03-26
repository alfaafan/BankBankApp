using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Domain;

namespace BankBankApp.Data.Interfaces
{
	public interface IRoleData : ICrudData<Role>
	{
		public Task<Role> GetRoleByName(string name);
		public Task<Task> AddUserToRole(User user, Role role);
		public Task<Task> RemoveUserFromRole(User user, Role role);
		public Task<IEnumerable<Role>> GetUserRolesByUsername(string username);
	}
}
