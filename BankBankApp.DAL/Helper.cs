using System;
using System.Collections.Generic;
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
    }
}
