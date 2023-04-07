using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("organization-members")]
    public class OrganizationMemberController : Controller
    {
        private IOrganizationMemberRepository organizationMemberService;

        public OrganizationMemberController(IOrganizationMemberRepository _organizationMemberService)
        {
            organizationMemberService = _organizationMemberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrganizationMember>>> Get()
        {
            return organizationMemberService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<OrganizationMember>> Add(OrganizationMember organizationMember)
        {
            organizationMemberService.Add(organizationMember);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<OrganizationMember>> Update(OrganizationMember organizationMember)
        {
            organizationMemberService.Update(organizationMember);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<OrganizationMember>> Remove(OrganizationMember organizationMember)
        {
            organizationMemberService.Remove(organizationMember);

            return NoContent();
        }
    }
}
