using System.Collections.Generic;
using AutoMapper;
using Piast.Api.Domain.Entities;
using Piast.Api.Infrastructure.Converters.Interfaces;
using Piast.Api.Infrastructure.DTO;

namespace Piast.Api.Infrastructure.Converters
{
    public class AdvertisementConverter : IAdvertisementConverter
    {
        private IMapper _mapper;
        public AdvertisementConverter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AdvertisementDTO Convert(Advertisement entity)
        {
            return _mapper.Map<Advertisement,AdvertisementDTO>(entity);
        }

        public Advertisement Convert(AdvertisementDTO dto)
        {
            return _mapper.Map<AdvertisementDTO,Advertisement>(dto);
        }

        public IList<AdvertisementDTO> Convert(IList<Advertisement> entities)
        {
            return _mapper.Map<IList<Advertisement>,IList<AdvertisementDTO>>(entities);
        }

        public IList<Advertisement> Convert(IList<AdvertisementDTO> dtos)
        {
            return _mapper.Map<IList<AdvertisementDTO>,IList<Advertisement>>(dtos);
        }
    }
}