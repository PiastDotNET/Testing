using System;

namespace Piast.Api.Infrastructure.DTO
{
    public class AdvertisementDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}