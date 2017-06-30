using System;
using Autofac;
using Common.Dependencies.SQL;
using Presentation.iOS.Classes.DependencyClients;
using Common.Dependencies.Mapper;
using Common.Dependencies.Error;
using Common.Dependencies.Networking;
using Common.Dependencies.Preferences;

namespace Presentation.iOS.Classes.Configuration.Autofac
{
	public class DependencyModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			builder.RegisterType<SQLiteConnectionClient> ().As<ISQLiteConnectionDependency> ();
			builder.RegisterType<MapperClient> ().As<IMapperDependency> ();
			builder.RegisterType<ErrorReportingClient> ().As<IErrorReportingDependency> ();
			builder.RegisterType<NetworkClient> ().As<INetworkDependency> ();
			builder.RegisterType<UserPreferences>().As<IUserPreferences>();
		}
	}
}

