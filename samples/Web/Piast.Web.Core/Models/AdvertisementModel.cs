using System;

namespace Piast.Web.Core.Models
{
    public class AdvertisementModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}