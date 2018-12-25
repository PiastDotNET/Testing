using System.Collections.Generic;
using Piast.Api.Domain.Entities;
using Piast.Api.Infrastructure.DTO;

namespace Piast.Api.Infrastructure.Converters.Interfaces
{
    public interface IAdvertisementConverter
    {
        AdvertisementDTO Convert(Advertisement entity);
        Advertisement Convert(AdvertisementDTO dto);

        IList<AdvertisementDTO> Convert(IList<Advertisement> entities);
        IList<Advertisement> Convert(IList<AdvertisementDTO> dtos);
    }
}