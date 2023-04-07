using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IOrganizationMemberRepository
    {
        public List<OrganizationMember> Get();

        public void Add(OrganizationMember organizationMember);

        public void Update(OrganizationMember organizationMember);

        public void Remove(OrganizationMember organizationMember);
    }
}