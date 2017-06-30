using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Dependencies.Mapper;
using Common.Dependencies.Preferences;
using Common.Enum;
using Common.Exceptions;
using Constants;
using Domain.Models;
using Infraestructure.Data;
using Infraestructure.DTO;
using Infraestructure.Entities;
using Infraestructure.WS;

namespace Domain.Services
{

	public interface IProspectService
	{
        List<ProspectModel> GetProspects();
		Task<bool> GetProspectsAsync();
        ProspectModel UpdateProspect(ProspectModel prospect);
        void CreateProspectLog(ProspectLogModel prospectLog);
        List<ProspectLogModel> GetProspectLogs();
	}

	public class ProspectService : IProspectService
	{
        private IWSProspectRepository _wsProspectRepository;
        private IProspectRepository _prospectRepository;
        private IProspectLogRepository _prospectLogRepository;
		private IUserPreferences _userPreferences;
		private IMapper _mapper;

		public ProspectService(IWSProspectRepository wsProspectRepository, IProspectRepository prospectRepository, IProspectLogRepository prospectLogRepository, IMapperDependency mapperDependency, IUserPreferences userPreferences)
		{
            _wsProspectRepository = wsProspectRepository;
            _prospectRepository = prospectRepository;
            _prospectLogRepository = prospectLogRepository;
			_mapper = mapperDependency.GetMapper();
			_userPreferences = userPreferences;
		}

        public async Task<bool> GetProspectsAsync()
        {
            bool syncProspects = _userPreferences.GetStoreBoolValue(GlobalConfig.SYNC_PROSPECTS);
            if (syncProspects) 
            {
				var dtos = await _wsProspectRepository.GetProspectsAsync();
                _prospectRepository.DeleteAll();
                _prospectLogRepository.DeleteAll();
				foreach (var dto in dtos)
				{
                    InsertEntity(dto);
				}
				_userPreferences.StoreBoolValue(GlobalConfig.SYNC_PROSPECTS, false);
            }
            return true;
        }

		public List<ProspectModel> GetProspects()
		{
			var entities = _prospectRepository.GetAll();
			var models = _mapper.Map<List<ProspectModel>>(entities);
			return models;
		}

        private void InsertEntity(ProspectDTO item)
		{
			var entity = _mapper.Map<ProspectEntity>(item);
			entity.ImgStatus = GetStatusBy(entity.statusCd)[0];
			entity.StatusName = GetStatusBy(entity.statusCd)[1];
			entity.StatusColor = GetStatusBy(entity.statusCd)[2];
			_prospectRepository.Insert(entity);
		}

		public ProspectModel UpdateProspect(ProspectModel prospect)
		{
            ValidateProspect(prospect);
            var entity = _mapper.Map<ProspectEntity>(prospect);
            _prospectRepository.Update(entity);
            var prospectLog = new ProspectLogModel()
            {
                Id = 0,
                ProspectId = entity.id,
                Name = entity.name,
                CreationDate = DateTime.Now
            };
            CreateProspectLog(prospectLog);
            return _mapper.Map<ProspectModel>(entity);
		}

		public void CreateProspectLog(ProspectLogModel prospectLog)
		{
            var entity = _mapper.Map<ProspectLogEntity>(prospectLog);
            _prospectLogRepository.Insert(entity);
		}

		public List<ProspectLogModel> GetProspectLogs()
		{
            var entities = _prospectLogRepository.GetAll();
            return _mapper.Map<List<ProspectLogModel>>(entities);
		}

        private List<string> GetStatusBy(int statusCd)
        {
            var status = new List<string> ();
            switch (statusCd)
            {
                case (int)ProspectStatusEnum.PENDING:
                    status.Add("iconPending.png");
                    status.Add("Pending");
                    status.Add("18,141,197");
                    break;
                case (int)ProspectStatusEnum.APPROVED:
                    status.Add("iconApproved.png");
                    status.Add("Approved");
                    status.Add("255,221,21");
					break;
                case (int)ProspectStatusEnum.ACCEPTED:
                    status.Add("iconAccepted.png");
                    status.Add("Accepted");
                    status.Add("62,153,28");
					break;
                case (int)ProspectStatusEnum.REJECTED:
                    status.Add("iconRejected.png");
                    status.Add("Rejected");
                    status.Add("255,95,95");
					break;
                case (int)ProspectStatusEnum.DISABLED:
                    status.Add("iconDisabled.png");
                    status.Add("Disabled");
                    status.Add("255,0,0");
					break;
            }
            return status;
        }

		private void ValidateProspect(ProspectModel prospect)
		{
			if (string.IsNullOrWhiteSpace(prospect.name))
			{
                throw new GeneralException(Messages.Name);
			}
            if (string.IsNullOrWhiteSpace(prospect.surname))
			{
                throw new GeneralException(Messages.LastName);
			}
            if (string.IsNullOrWhiteSpace(prospect.telephone))
			{
                throw new GeneralException(Messages.Phone);
			}
            if (string.IsNullOrWhiteSpace(prospect.address))
			{
                throw new GeneralException(Messages.Address);
			}
            if (string.IsNullOrWhiteSpace(prospect.zoneCode))
			{
                throw new GeneralException(Messages.Zone);
			}
            if (string.IsNullOrWhiteSpace(prospect.sectionCode))
			{
                throw new GeneralException(Messages.Section);
			}
            if (string.IsNullOrWhiteSpace(prospect.cityCode))
			{
                throw new GeneralException(Messages.City);
			}
            if (string.IsNullOrWhiteSpace(prospect.neighborhoodCode))
			{
                throw new GeneralException(Messages.Neighborhood);
			}
            if (string.IsNullOrWhiteSpace(prospect.observation))
			{
                prospect.observation = string.Empty;
			}
		}

    }
}
