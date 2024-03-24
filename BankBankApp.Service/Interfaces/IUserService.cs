using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankBankApp.Service.DTOs;

namespace BankBankApp.Service.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserDTO>> GetAll();
		Task<UserDTO> Get(int id);
		Task<UserDTO> GetByUsername(string username);
		Task<UserDTO> GetWithAccountAndCard(int id);
		Task<UserDTO> Create(RegisterDTO user);
		Task<UserDTO> Update(UserUpdateDTO user);
		Task<bool> Delete(int id);
		Task<UserDTO> Login(LoginDTO login);

	}
}
