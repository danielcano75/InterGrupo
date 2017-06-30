using System;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Dependencies.Mapper;
using Common.Dependencies.Preferences;
using Common.Exceptions;
using Common.Helper;
using Constants;
using Domain.Models;
using Infraestructure.DTO;
using Infraestructure.Repositories.Data;
using Infraestructure.WS;

namespace Domain.Services
{
	public interface IUserService
	{
		Task<bool> LoginAsync(LoginModel login);
        void LogOut();
	}

	public class UserService : IUserService
	{
		private IWSUserRepository _wsUserRepository;
		private IUserRepository _userRepository;
		private IUserPreferences _userPreferences;
		private IMapper _mapper;

		public UserService(IWSUserRepository wsUserRepository, IMapperDependency mapperDependency, IUserRepository userRepository, IUserPreferences userPreferences)
		{
			_wsUserRepository = wsUserRepository;
			_userRepository = userRepository;
			_mapper = mapperDependency.GetMapper();
			_userPreferences = userPreferences;
		}

		public async Task<bool> LoginAsync(LoginModel login)
		{
			ValidateLogin(login);
			var request = _mapper.Map<LoginDTO>(login);
			var user = await _wsUserRepository.LoginAsync(request);
			if (user.success) 
			{
				_userPreferences.StoreStringValue(GlobalConfig.TOKEN, user.authToken);
                _userPreferences.StoreBoolValue(GlobalConfig.SYNC_PROSPECTS, true);
			}
			return user.success;
		}

        public void LogOut()
        {
            _userPreferences.StoreStringValue(GlobalConfig.TOKEN, string.Empty);
        }

        private void ValidateLogin(LoginModel login)
		{
			if (!GeneralHelper.isValidEmail(login.email)) { 
				throw new GeneralException(Messages.Email);
			}
			if (string.IsNullOrWhiteSpace(login.password)) { 
				throw new GeneralException(Messages.Password);
			}
		}

	}
}

