using System;
using Common.Dependencies.SQL;
using Infraestructure.Entities;
using Infraestructure.Repositories.Base.Data;

namespace Infraestructure.Data
{
	public interface IProspectLogRepository : ICRUDRepository<ProspectLogEntity>
	{
		
	}

	public class ProspectLogRepository : BaseCRUDRepository<ProspectLogEntity>, IProspectLogRepository
	{
		public ProspectLogRepository(ISQLiteConnectionDependency sqliteConnection) : base(sqliteConnection)
		{
		}

		
	}
}
