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
    public class DetailsModel : PageModel
    {
        private readonly IAdvertisementService _service;
        public AdvertisementModel Advertisement { get; set; }
        public DetailsModel(IAdvertisementService service)
        {
            _service = service;
        }
        public async Task OnGetAsync(Guid id)
        {
            Advertisement = await _service.FindById(id);
        }
    }
}