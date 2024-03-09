using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BankBankApp.BLL
{
    public class Helper
    {
        public static string GetRandomPassword()
        {
            string password = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                password += (char)random.Next(65, 90);
            }
            return password;
        }
        public static string GetHash(string input)
        {
            var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var bytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = sha1.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
