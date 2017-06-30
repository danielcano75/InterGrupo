using System;
using System.Collections.Generic;
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
	public interface IWSProspectRepository
	{
		Task<List<ProspectDTO>> GetProspectsAsync();
	}

	public class WSProspectRepository : WSBaseRepository, IWSProspectRepository
	{
		public WSProspectRepository(INetworkDependency networkDependency, IErrorReportingDependency errorReportingDependency, IMapperDependency mapperDependency, IUserPreferences userPreferences) : base(networkDependency, errorReportingDependency, mapperDependency, userPreferences)
		{
		}

		public async Task<List<ProspectDTO>> GetProspectsAsync()
		{
			var response = default(List<ProspectDTO>);

			using (var client = new JsonApiClient(GlobalConfig.BASE_URL, NetworkDependency, UserPreferences))
			{
                response = await client.GetAsync<List<ProspectDTO>>("/sch/prospects.json", true);
			}

			return response;
		}
	}
}
