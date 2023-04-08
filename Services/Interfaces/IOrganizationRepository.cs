using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IOrganizationRepository
    {
        public Task<List<Organization>> Get();

        public Task Add(Organization organization);

        public Task Update(Organization organization);

        public Task Remove(Organization organization);
    }
}