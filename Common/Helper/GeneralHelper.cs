using System;
using System.Text.RegularExpressions;

namespace Common.Helper
{
	public class GeneralHelper
	{
		public GeneralHelper()
		{
		}

		public static Regex EmailRegex 
		{ 
			get 
			{ 
				return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); 
			}
		}

		public static bool isValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			return EmailRegex.IsMatch(email);
		}
	}
}

