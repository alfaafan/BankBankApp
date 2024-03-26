using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankBankApp.Data.Interfaces;
using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;

namespace BankBankApp.Service
{
	public class RoleService : IRoleService
	{
		private readonly IRoleData _roleData;
		private readonly IMapper _mapper;

		public RoleService(IRoleData roleData, IMapper mapper)
		{
			_roleData = roleData;
			_mapper = mapper;
		}
		public Task<Task> AddUserToRole(UserDTO user, RoleDTO role)
		{
			throw new NotImplementedException();
		}

		public async Task<RoleDTO> CreateRole(RoleDTO role)
		{
			try
			{
				var roleEntity = _mapper.Map<Domain.Role>(role);
				var createdRole = await _roleData.Add(roleEntity);
				return _mapper.Map<RoleDTO>(createdRole);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<RoleDTO> GetRoleByName(string name)
		{
			try
			{
				var role = await _roleData.GetRoleByName(name);
				return _mapper.Map<RoleDTO>(role);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<RoleDTO>> GetUserRolesByUsername(string username)
		{
			try
			{
				var roles = await _roleData.GetUserRolesByUsername(username);
				return _mapper.Map<IEnumerable<RoleDTO>>(roles);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<Task> RemoveUserFromRole(UserDTO user, RoleDTO role)
		{
			throw new NotImplementedException();
		}
	}
}
