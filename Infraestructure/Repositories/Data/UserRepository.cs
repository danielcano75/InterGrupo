using System;
using System.Collections.Generic;
using Common.Dependencies.SQL;
using Infraestructure.Entities;
using Infraestructure.Repositories.Base.Data;

namespace Infraestructure.Repositories.Data
{

	public interface IUserRepository : ICRUDRepository<UserEntity>
	{
		
	}

	public class UserRepository : BaseCRUDRepository<UserEntity>, IUserRepository
	{
		public UserRepository(ISQLiteConnectionDependency sqliteConnection) : base(sqliteConnection)
		{
		}
	}
}

