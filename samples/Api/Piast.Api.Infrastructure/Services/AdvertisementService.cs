using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories.Interfaces;
using Piast.Api.Infrastructure.Converters.Interfaces;
using Piast.Api.Infrastructure.DTO;
using Piast.Api.Infrastructure.Services.Interfaces;

namespace Piast.Api.Infrastructure.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementConverter _converter;
        private readonly IRepository<Advertisement> _repository;
        public AdvertisementService(
            IAdvertisementConverter converter,
            IRepository<Advertisement> repository)
        {
            _converter = converter;
            _repository = repository;
        }
        public async Task AddAsync(AdvertisementDTO model)
        {
            var entity = _converter.Convert(model);
            await _repository.AddAsync(entity);
        }

        public async Task<AdvertisementDTO> FindFirstByIdAsync(Guid id)
        {
            return _converter.Convert(await _repository.FindFirstAsync(x=>x.Id.Equals(id)));
        }

        public async Task<IList<AdvertisementDTO>> FindPageAsync(int page, int pageCount)
        {
            return _converter.Convert(await _repository.FindManyAsync(x=>true,page,pageCount));
        }
    }
}