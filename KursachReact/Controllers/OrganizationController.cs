using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("organizations")]
    public class OrganizationController : Controller
    {
        private IOrganizationRepository organizationService;

        public OrganizationController(IOrganizationRepository _organizationService)
        {
            organizationService = _organizationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Organization>>> Get()
        {
            return await organizationService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Organization>> Add(Organization volonteerInfo)
        {
            await organizationService.Add(volonteerInfo);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Organization>> Update(Organization volonteerInfo)
        {
            await organizationService.Update(volonteerInfo);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Organization>> Remove(Organization volonteerInfo)
        {
            await organizationService.Remove(volonteerInfo);

            return NoContent();
        }
    }
}
