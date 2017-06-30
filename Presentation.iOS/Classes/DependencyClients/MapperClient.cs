using System;
using Common.Dependencies.Mapper;

namespace Presentation.iOS.Classes.DependencyClients
{
	public class MapperClient : IMapperDependency
	{
		public MapperClient ()
		{
		}

		#region IMapperDependency implementation

		public AutoMapper.IMapper GetMapper ()
		{
			return AppDelegate.LocalConfig.Mapper;
		}

		#endregion
	}
}

