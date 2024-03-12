using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BankBankApp.DAL
{
	public class Helper
	{
		public static string GetConnectionString()
		{
			if (System.Configuration.ConfigurationManager.ConnectionStrings["BankBankConnectionString"] == null)
			{
				var config = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.Build();
				return config.GetConnectionString("BankBankConnectionString");
			}

			var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BankBankConnectionString"].ConnectionString;
			return connectionString;
		}

		public static string GenerateAccountNumber()
		{
			string guid = Guid.NewGuid().ToString("N");

			StringBuilder accountNumber = new StringBuilder();
			foreach (char c in guid)
			{
				accountNumber.Append(char.IsDigit(c) ? c : '1');
			}

			return accountNumber.ToString().Substring(0, 6);
		}

		public static string GenerateCardNumber()
		{
			string guid = Guid.NewGuid().ToString("N");

			StringBuilder accountNumber = new StringBuilder();
			foreach (char c in guid)
			{
				accountNumber.Append(char.IsDigit(c) ? c : '1');
			}

			return accountNumber.ToString().Substring(0, 13);
		}

	}
}
