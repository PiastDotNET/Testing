using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories.Interfaces;

namespace Piast.Api.Tests.Pact.Fakes
{
    public class FakeRepository : IRepository<Advertisement>
    {
        public Task AddAsync(Advertisement entity)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> FindFirstAsync(Expression<Func<Advertisement, bool>> predicate)
        {
            return Task.FromResult(new Advertisement(){
                Id = Guid.Parse("debdedbf-1524-4d83-8d74-7d05ffb02d6e"),
                Title = "Title",
                Description = "Description",
                Price = 1,
                PublicationDate = new DateTime(2019,01,10)
            });
        }

        public Task<IList<Advertisement>> FindManyAsync(Expression<Func<Advertisement, bool>> predicate, int page = 1, int pageCount = 20)
        {
            throw new NotImplementedException();
        }
    }
}