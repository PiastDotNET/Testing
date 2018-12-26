using System.Collections.Generic;

namespace Piast.Web.Core.Models
{
    public class PageModel<T>
    {
        public IList<T> Items { get; set; }
        public bool NextPageAvailable { get; set; }
    }
}