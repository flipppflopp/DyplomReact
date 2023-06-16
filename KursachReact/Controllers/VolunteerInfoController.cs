using DB.Models;
using Dyplom.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/volonteer-infoes")]
    public class VolonteerInfoController : Controller
    {
        private IVolonteerInfoRepository volonteerInfoService;

        public VolonteerInfoController(IVolonteerInfoRepository _volonteerInfoService)
        {
            volonteerInfoService = _volonteerInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VolonteerInfo>>> Get()
        {
            return await volonteerInfoService.Get();
        }

        [HttpGet]
        [Route("single-volonteer/{username}")]
        public async Task<ActionResult<VolonteerInfo>> GetByName(string username)
        {
            return await volonteerInfoService.GetByName(username);
        }

        [HttpGet]
        [Route("volonteers/{username}")]
        public async Task<ActionResult<List<User>>> GetVolonteers(string username)
        {
            return await volonteerInfoService.GetVolonteers(username);
        }

        [HttpGet]
        [Route("subs/{volonteer}/{sub}")]
        public async Task<ActionResult<bool>> IsSub(string volonteer, string sub)
        {
            return await volonteerInfoService.IsSub(volonteer, sub);
        }

        [HttpPost]
        [Route("sub")]
        public async Task<ActionResult<bool>> AddSubscriber(object nameVolonteer)
        {
            SubVolonteer subVol = TypeHelper.ObjToType<SubVolonteer>(nameVolonteer);

            return await volonteerInfoService.AddSubscriber(subVol.sub, subVol.volonteer);
        }

        [HttpGet]
        [Route("check-status/{id}")]
        public async Task<ActionResult<User>> GetVolonteerByInfoId(int id)
        {
            return await volonteerInfoService.GetVolonteerByInfoId(id);
        }

        [HttpPost]
        public async Task<ActionResult<VolonteerInfo>> Add(VolonteerInfo volonteerInfo)
        {
            await volonteerInfoService.Add(volonteerInfo);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<VolonteerInfo>> Update(VolonteerInfo volonteerInfo)
        {
            await volonteerInfoService.Update(volonteerInfo);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<VolonteerInfo>> Remove(VolonteerInfo volonteerInfo)
        {
            await volonteerInfoService.Remove(volonteerInfo);

            return NoContent();
        }
    }
}
