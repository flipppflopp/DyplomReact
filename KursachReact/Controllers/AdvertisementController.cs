using DB.Models;
using Dyplom.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/advertisements")]
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
            return await advertisementService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Advertisement>> GetById(int id)
        {
            return await advertisementService.GetById(id);
        }

        [HttpGet]
        [Route("creator/{username}")]
        public async Task<ActionResult<List<Advertisement>>> GetByVolonteerName(string username)
        {
            return await advertisementService.GetByVolonteerName(username);
        }

        [HttpGet]
        [Route("get-photoes/{id}")]
        public async Task<ActionResult<List<Photo>>> GetPhotoes(int id)
        {
            return await advertisementService.GetPhotoes(id);
        }

        [HttpPost]
        public async Task<ActionResult<Advertisement>> Add(Advertisement advertisement)
        {
            await advertisementService.Add(advertisement);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Advertisement>> Update(Advertisement advertisement)
        {
            await advertisementService.Update(advertisement);

            return NoContent();
        }

        [HttpPut]
        [Route("create-transaction")]
        public async Task<ActionResult<bool>> CreateTransaction(object AdUserExpense)
        {
            AdUserExpense typed = TypeHelper.ObjToType<AdUserExpense>(AdUserExpense);

            await advertisementService.CreateTransaction(typed.Username, typed.Amount, typed.adId);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Advertisement>> Remove(Advertisement advertisement)
        {
            await advertisementService.Remove(advertisement);

            return NoContent();
        }
    }
}
