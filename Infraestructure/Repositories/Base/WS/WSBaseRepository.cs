using System;
using Common.Dependencies.Error;
using Common.Dependencies.Mapper;
using Common.Dependencies.Networking;
using Common.Dependencies.Preferences;

namespace Infraestructure.WS
{
	public class WSBaseRepository
	{
	protected IErrorReportingDependency ErrorReportingDependency
	{
		get;
		set;
	}

	protected INetworkDependency NetworkDependency
	{
		get;
		set;
	}

	protected IMapperDependency MapperDependency
	{
		get;
		set;
	}

	protected IUserPreferences UserPreferences
	{
		get;
		set;
	}

	public WSBaseRepository(INetworkDependency networkDependency, IErrorReportingDependency errorReportingDependency, IMapperDependency mapperDependency, IUserPreferences userPreferences)
	{
		NetworkDependency = networkDependency;
		ErrorReportingDependency = errorReportingDependency;
		MapperDependency = mapperDependency;
		UserPreferences = userPreferences;
	}
	}
}

