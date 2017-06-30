using System;

namespace Infraestructure.Repositories.Base.Data
{
	public interface IUpdateRepository<T> where T: class
	{
			void Update(T entity);
	}
}

