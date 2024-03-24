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
	public class AccountService : IAccountService
	{
		private readonly IAccountData _accountData;
		private readonly IMapper _mapper;
		public AccountService(IAccountData accountData, IMapper mapper)
		{
			_accountData = accountData;
			_mapper = mapper;
		}
		public async Task<AccountDTO> GetAccountByAccountNumber(string accountNumber)
		{
			try
			{
				var account = await _accountData.GetByAccountNumber(accountNumber);
				return _mapper.Map<AccountDTO>(account);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<AccountDTO> GetAccountById(int id)
		{
			try
			{
				var account = await _accountData.Get(id);
				return _mapper.Map<AccountDTO>(account);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<AccountDTO>> GetAccounts()
		{
			try
			{
				var accounts = await _accountData.GetAll();
				return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<AccountDTO> UpdateAccount(AccountDTO account)
		{
			try
			{
				var accountToUpdate = _mapper.Map<Account>(account);
				var updatedAccount = await _accountData.Update(accountToUpdate);
				return _mapper.Map<AccountDTO>(updatedAccount);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
