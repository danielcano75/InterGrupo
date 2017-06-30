using System;
using AutoMapper;
using Domain.Models;
using Infraestructure.DTO;
using Infraestructure.Entities;
//using Infraestructure.Entities;
//using Domain.Models;
//using Infraestructure.DTO;

namespace Configuration
{
	public static class AutomapperConfig
	{
		
		public static IMapper CreateMapper(){
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<EntityModelProfile>();
				cfg.AddProfile<DtoEntityProfile>();

			});
			return config.CreateMapper ();
		}

		private class EntityModelProfile : Profile{

			protected override void Configure() 
			{
				// Entity TO Models And Reverse Map
				CreateMap<ProspectEntity, ProspectModel>().ReverseMap();
                CreateMap<ProspectLogEntity, ProspectLogModel>().ReverseMap();

				// DTO TO Models And Reverse Map
				CreateMap<LoginDTO, LoginModel>().ReverseMap();
			}
		}

		private class DtoEntityProfile : Profile{

			protected override void Configure() 
			{
				// DTO TO ENTITIES And Reverse Map
                CreateMap<ProspectDTO, ProspectEntity>().ReverseMap();
				//CreateMap<CompanyDTO,CompanyEntity> ()
				//	.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image));
			}
		}



	}
}

