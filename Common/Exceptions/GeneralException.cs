using System;

namespace Common.Exceptions
{
	public class GeneralException : Exception
	{
		public GeneralException ()
		{
		}

		public GeneralException(string message) : base (message)
		{
		}

	}
}

