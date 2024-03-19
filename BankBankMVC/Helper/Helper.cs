using System.Globalization;

namespace BankBankApp.MVC.Helper
{
	public class Helper
	{
		public static string ToRupiahFormat(decimal value)
		{
			CultureInfo culture = new CultureInfo("id-ID");
			return value.ToString("C2", culture).Replace("$", "Rp ");
		}

		public static string FormatCardNumber(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return "No Card";
			}

			int chunkSize = 4;
			List<string> parts = new List<string>();

			for (int i = 0; i < text.Length; i += chunkSize)
			{
				int chunkLength = Math.Min(chunkSize, text.Length - i);
				parts.Add(text.Substring(i, chunkLength));
			}

			return string.Join("	", parts);
		}

		public static string FormatExpirationDate(DateTime date)
		{
			return $"{date.ToString("MM/yy")}";
		}
	}
}
