using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IOrganizationRepository
    {
        public List<Organization> Get();

        public void Add(Organization organization);

        public void Update(Organization organization);

        public void Remove(Organization organization);
    }
}