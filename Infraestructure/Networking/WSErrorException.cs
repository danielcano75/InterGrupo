using System;

namespace Infraestructure.Networking
{
	public class WSErrorException: Exception
	{
		public WSErrorException ()
		{
		}

		public WSErrorException(string message) : base (message)
		{
		}

		public WSErrorException(string message,Exception innerException) : base (message,innerException)
		{
		}
	}
}