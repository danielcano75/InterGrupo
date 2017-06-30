using System;
using System.Collections.Generic;

namespace Infraestructure.Repositories.Base.Data
{
	public interface IReadRepository<T> where T: class
	{
		T GetByPrimaryKey (object id);
		List<T> GetAll();
	}
}

