using System;

namespace Piast.Api.Domain.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}