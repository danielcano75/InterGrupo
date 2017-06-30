using System;
namespace Infraestructure.Entities
{
	public class UserEntity
	{
		public UserEntity()
		{
		}

		public bool success { get; set; }
		public string authToken { get; set; }
		public string email { get; set; }
		public string zone { get; set; }
	}
}

