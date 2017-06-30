using System;
using System.Linq;
using Common.Dependencies.SQL;
using Infraestructure.Entities;
using Infraestructure.Repositories.Base.Data;

namespace Infraestructure.Data
{
	public interface IProspectRepository : ICRUDRepository<ProspectEntity>
	{
        ProspectEntity GetBy(string id);
	}

	public class ProspectRepository : BaseCRUDRepository<ProspectEntity>, IProspectRepository
	{
		public ProspectRepository(ISQLiteConnectionDependency sqliteConnection) : base(sqliteConnection)
        {
		}

        public ProspectEntity GetBy(string id)
        {
            return Table.ToList().Where(pr => pr.id.Equals(id)).FirstOrDefault();
        }
    }
}
