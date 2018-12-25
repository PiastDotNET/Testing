using System.Collections.Generic;
using AutoMapper;
using Piast.Api.Domain.Entities;
using Piast.Api.Infrastructure.DTO;

namespace Piast.Api.Infrastructure.Converters.Profiles
{
    public class AdvertisementMappingProfile : Profile
    {
        public AdvertisementMappingProfile()
        {
            CreateMap<Advertisement,AdvertisementDTO>();
            CreateMap<AdvertisementDTO,Advertisement>();
            CreateMap<IList<Advertisement>,IList<AdvertisementDTO>>();
            CreateMap<IList<AdvertisementDTO>,IList<Advertisement>>();
        }
    }
}