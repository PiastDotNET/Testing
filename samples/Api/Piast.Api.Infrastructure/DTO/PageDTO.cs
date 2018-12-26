using System.Collections.Generic;

namespace Piast.Api.Infrastructure.DTO
{
    public class PageDTO<T> 
    {
        public IList<T> Items { get; set; }
        public bool NextPageAvailable { get; set; }
    }
}