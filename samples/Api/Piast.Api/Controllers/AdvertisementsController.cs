using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Piast.Api.Infrastructure.DTO;
using Piast.Api.Infrastructure.Services.Interfaces;

namespace Piast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementService _service;
        public AdvertisementsController(IAdvertisementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page = 1,[FromQuery]int pageCount = 20)
        {
            return Ok(await _service.FindPageAsync(page,pageCount));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            return Ok(await _service.FindFirstByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AdvertisementDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }
    }
}