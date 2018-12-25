using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Piast.Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}