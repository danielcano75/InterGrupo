using System;
using Autofac;
using Common.Dependencies.Preferences;
using Domain.Services;

namespace Presentation.iOS.Controllers._Shared.Services
{
	public class ServiceFactory
	{
		public ServiceFactory()
		{
		}

		private IUserService _userService;
		public IUserService UserService
		{

			get
			{

				if (_userService == null)
				{
					_userService = AppDelegate.LocalConfig.Container.Resolve<IUserService>();
				}
				return _userService;

			}

		}

        private IProspectService _prospectService;
		public IProspectService ProspectService
		{

			get
			{

				if (_prospectService == null)
				{
					_prospectService = AppDelegate.LocalConfig.Container.Resolve<IProspectService>();
				}
				return _prospectService;

			}

		}

		private IUserPreferences _preferences;
		public IUserPreferences Preferences
		{

			get
			{

				if (_preferences == null)
				{
					_preferences = AppDelegate.LocalConfig.Container.Resolve<IUserPreferences>();
				}
				return _preferences;

			}

		}

	}
}

