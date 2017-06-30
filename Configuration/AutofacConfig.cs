using System;
using Autofac;

using Domain.Services;
using System.Reflection;
using Infraestructure.Repositories.Data;

namespace Configuration
{
	public static class AutofacConfig
	{
		public static ContainerBuilder CreateBuilder()
		{
			var builder = new ContainerBuilder ();
			builder.RegisterModule<RepositoryModule> ();
			builder.RegisterModule<ServiceModule> ();
			return builder;
		}

		private class RepositoryModule: Autofac.Module
		{
			protected override void Load (ContainerBuilder builder)
			{
				var assembly = typeof(UserRepository).GetTypeInfo().Assembly;

				builder.RegisterAssemblyTypes(assembly)
					.Where(t => t.Name.EndsWith("Repository"))
					.AsImplementedInterfaces();
			}
		}

		private class ServiceModule: Autofac.Module
		{
			protected override void Load (ContainerBuilder builder)
			{

				var assembly = typeof(IUserService).GetTypeInfo().Assembly;

				builder.RegisterAssemblyTypes(assembly)
					.Where(t => t.Name.EndsWith("Service"))
					.AsImplementedInterfaces();

			}
		}



	}
}

