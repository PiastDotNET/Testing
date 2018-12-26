using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Piast.Web.Core.Models;
using Piast.Web.Core.Services.Interfaces;

namespace Piast.Web.Pages
{
    public class IndexModel : PageModel
    {
        private const int DefaultPageCount = 20;
        private readonly IAdvertisementService _service;
        public PageModel<AdvertisementModel> ItemsPage { get; set; }
        public int NextPageNumber { get; set; }
        public int PreviousPageNumber { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageCount { get; set; }
        public IndexModel(IAdvertisementService service)
        {
            _service = service;
            PageCount = DefaultPageCount;
        }
        public async Task OnGetAsync(int pageNumber)
        {
            NextPageNumber = pageNumber+1;
            PreviousPageNumber = pageNumber-1;
            ItemsPage = await _service.GetPage(pageNumber, PageCount);
            ItemsPage.PreviousPageAvailable = PreviousPageNumber != 0;
        }
    }
}
