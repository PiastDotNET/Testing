﻿using System;
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
        private readonly IAdvertisementService _service;
        public PageModel<AdvertisementModel> ItemsPage { get; set; }
        public IndexModel(IAdvertisementService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {
            ItemsPage = await _service.GetPage(1,20);
        }
    }
}
