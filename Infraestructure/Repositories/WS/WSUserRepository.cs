using System;
using System.Threading.Tasks;
using Common.Dependencies.Error;
using Common.Dependencies.Mapper;
using Common.Dependencies.Networking;
using Common.Dependencies.Preferences;
using Constants;
using Infraestructure.DTO;
using Infraestructure.Entities;
using Infraestructure.Networking;

namespace Infraestructure.WS
{
	public interface IWSUserRepository
	{
		Task<UserEntity> LoginAsync(LoginDTO login);
	}

	public class WSUserRepository : WSBaseRepository, IWSUserRepository
	{
		public WSUserRepository(INetworkDependency networkDependency, IErrorReportingDependency errorReportingDependency, IMapperDependency mapperDependency, IUserPreferences userPreferences) : base(networkDependency, errorReportingDependency, mapperDependency, userPreferences)
		{
		}

		public async Task<UserEntity> LoginAsync(LoginDTO login)
		{
			var response = default(UserEntity);
			string apiURL = "/application/login?email=" + login.email + "&password=" + login.password;

			using (var client = new JsonApiClient(GlobalConfig.BASE_URL, NetworkDependency, UserPreferences))
			{
				response = await client.GetAsync<UserEntity>(apiURL);
			}

			return response;
		}
	}
}

