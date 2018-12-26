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
    public class AddModel : PageModel
    {
        private readonly IAdvertisementService _service;
        [BindProperty]
        public AdvertisementModel Advertisement { get; set; }
        public AddModel(IAdvertisementService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Advertisement = new AdvertisementModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await _service.Add(Advertisement);
            return RedirectToPage("/Index");
        }
    }
}