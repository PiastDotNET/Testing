using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Piast.Api.Domain.Entities;

namespace Piast.Api.Domain.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> FindFirstAsync(Expression<Func<T,bool>> predicate);

        Task<IList<T>> FindManyAsync(Expression<Func<T,bool>> predicate, int page = 1, int pageCount = 20);
        Task AddAsync(T entity);
    }
}