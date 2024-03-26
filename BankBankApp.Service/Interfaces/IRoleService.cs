using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Interfaces
{
	public interface IRoleService
	{
		public Task<RoleDTO> CreateRole(RoleDTO role);
		public Task<RoleDTO> GetRoleByName(string name);
		public Task<Task> AddUserToRole(UserDTO user, RoleDTO role);
		public Task<Task> RemoveUserFromRole(UserDTO user, RoleDTO role);
		public Task<IEnumerable<RoleDTO>> GetUserRolesByUsername(string username);
	}
}
