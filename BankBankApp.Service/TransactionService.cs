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
	public class TransactionService : ITransactionService
	{
		private readonly ITransactionData _transactionData;
		private readonly IMapper _mapper;
		public TransactionService(ITransactionData transactionData, IMapper mapper)
		{
			_transactionData = transactionData;
			_mapper = mapper;
		}
		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}


		public async Task<TransactionDTO> Deposit(DepositDTO transaction)
		{
			try
			{
				var transactionEntity = _mapper.Map<Transaction>(transaction);
				var createdTransaction = await _transactionData.Deposit(transactionEntity);
				return _mapper.Map<TransactionDTO>(createdTransaction);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<TransactionDTO> Get(int id)
		{
			try
			{
				var transaction = await _transactionData.Get(id);
				return _mapper.Map<TransactionDTO>(transaction);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<TransactionDTO>> GetAll()
		{
			try
			{
				var transactions = await _transactionData.GetAll();
				return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
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

		public async Task<IEnumerable<TransactionDTO>> GetByAccount(int accountID)
		{
			try
			{
				var transactions = await _transactionData.GetTransactionsByAccountId(accountID);
				return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<TransactionDTO> Transfer(TransferDTO transaction)
		{
			try
			{
				var transactionEntity = _mapper.Map<Transaction>(transaction);
				var createdTransaction = await _transactionData.Transfer(transactionEntity);
				return _mapper.Map<TransactionDTO>(createdTransaction);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<TransactionDTO> Withdraw(WithdrawDTO transaction)
		{
			try
			{
				var transactionEntity = _mapper.Map<Transaction>(transaction);
				var createdTransaction = await _transactionData.Withdraw(transactionEntity);
				return _mapper.Map<TransactionDTO>(createdTransaction);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
