using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("advertisements")]
    public class AdvertisementController : Controller
    {
        private IAdvertisementRepository advertisementService;

        public AdvertisementController(IAdvertisementRepository _advertisementService)
        {
            advertisementService = _advertisementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Advertisement>>> Get()
        {
            return advertisementService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Advertisement>> Add(Advertisement advertisement)
        {
            advertisementService.Add(advertisement);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Advertisement>> Update(Advertisement advertisement)
        {
            advertisementService.Update(advertisement);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Advertisement>> Remove(Advertisement advertisement)
        {
            advertisementService.Remove(advertisement);

            return NoContent();
        }
    }
}
