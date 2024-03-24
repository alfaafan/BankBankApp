using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankBankApp.Data.Interfaces;
using BankBankApp.Domain;
using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;

namespace BankBankApp.Service
{
	public class UserService : IUserService
	{
		private readonly IUserData _userData;
		private readonly IMapper _mapper;
		public UserService(IUserData userData, IMapper mapper)
		{
			_userData = userData;
			_mapper = mapper;
		}
		public async Task<UserDTO> Create(RegisterDTO user)
		{
			try
			{
				var userEntity = _mapper.Map<User>(user);
				var createdUser = await _userData.Add(userEntity);
				var userDTO = _mapper.Map<UserDTO>(createdUser);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var result = await _userData.Delete(id);
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserDTO> Get(int id)
		{
			try
			{
				var user = await _userData.Get(id);
				var userDTO = _mapper.Map<UserDTO>(user);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<UserDTO>> GetAll()
		{
			try
			{
				var users = await _userData.GetAll();
				var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
				return userDTOs;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserDTO> GetByUsername(string username)
		{
			try
			{
				var user = await _userData.GetByUsername(username);
				var userDTO = _mapper.Map<UserDTO>(user);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserDTO> GetWithAccountAndCard(int id)
		{
			try
			{
				var user = await _userData.GetWithAccountAndCard(id);
				var userDTO = _mapper.Map<UserDTO>(user);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserDTO> Login(LoginDTO login)
		{
			try
			{
				var user = await _userData.Login(login.Username, login.Password);
				if (user == null)
				{
					throw new Exception("Invalid login");
				}
				var userDTO = _mapper.Map<UserDTO>(user);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserDTO> Update(UserUpdateDTO user)
		{
			try
			{
				var userEntity = _mapper.Map<User>(user);
				var updatedUser = await _userData.Update(userEntity);
				var userDTO = _mapper.Map<UserDTO>(updatedUser);
				return userDTO;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
