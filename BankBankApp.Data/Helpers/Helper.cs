using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBankApp.Data.Helpers
{
	public class Helper
	{
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

		public static string GenerateTransactionNumber()
		{
			string guid = Guid.NewGuid().ToString("N");

			StringBuilder accountNumber = new StringBuilder();
			foreach (char c in guid)
			{
				accountNumber.Append(char.IsDigit(c) ? c : '1');
			}

			return accountNumber.ToString().Substring(0, 10);
		}

		public static string HashPassword(string password)
		{
			var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
			var bytes = System.Text.Encoding.ASCII.GetBytes(password);
			var hash = sha1.ComputeHash(bytes);
			var sb = new System.Text.StringBuilder();
			foreach (var b in hash)
			{
				sb.Append(b.ToString("X2"));
			}
			return sb.ToString();
		}

		public static bool VerifyPassword(string password, string hash)
		{
			return hash == HashPassword(password);
		}
	}
}
