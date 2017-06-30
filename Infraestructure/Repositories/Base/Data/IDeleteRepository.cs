using System;

namespace Infraestructure.Repositories.Base.Data
{
	public interface IDeleteRepository<T> where T: class
	{
		void Delete(T entity);
		void DeleteAll();
	}
}

