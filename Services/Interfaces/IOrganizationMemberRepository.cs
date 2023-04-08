using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IOrganizationMemberRepository
    {
        public Task<List<OrganizationMember>> Get();

        public Task Add(OrganizationMember organizationMember);

        public Task Update(OrganizationMember organizationMember);

        public Task Remove(OrganizationMember organizationMember);
    }
}