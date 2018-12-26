using System;
using Piast.Api.Domain.Attributes;

namespace Piast.Api.Domain.Entities
{
    [BsonCollection("Advertisements")]
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}