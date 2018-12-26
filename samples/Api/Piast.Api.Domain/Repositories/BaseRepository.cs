using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Piast.Api.Domain.Attributes;
using Piast.Api.Domain.Consts;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories.Interfaces;

namespace Piast.Api.Domain.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T :BaseEntity
    {
        private readonly IMongoDatabase _database;
        public BaseRepository(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(MongoConsts.MongoDatabaseName);
        }

        public async Task AddAsync(T entity)
        {
            var collection = _database.GetCollection<T>(GetCollectionName());
            await collection.InsertOneAsync(entity);
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _database.GetCollection<T>(GetCollectionName());
            return await collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> FindManyAsync(Expression<Func<T, bool>> predicate, int page = 1, int pageCount = 20)
        {
            var collection = _database.GetCollection<T>(GetCollectionName());
            return await collection
                .Find(predicate)
                .Skip((page-1)*pageCount)
                .Limit(pageCount+1)
                .ToListAsync();
        }

        private string GetCollectionName()
        {
            return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }
    }
}