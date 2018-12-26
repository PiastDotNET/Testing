using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Piast.Api.Infrastructure.DTO;

namespace Piast.Api.Infrastructure.Services.Interfaces
{
    public interface IAdvertisementService
    {
        Task<AdvertisementDTO> FindFirstByIdAsync(Guid id);

        Task<PageDTO<AdvertisementDTO>> FindPageAsync(int page, int pageCount);
        Task AddAsync(AdvertisementDTO model);
    }
}