using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Services.Interfaces;

namespace Services.Services
{
    public class OrganizationService : IOrganizationRepository
    {
        private readonly ApplicationContext db;
        
        public OrganizationService(ApplicationContext context)
        {
            db = context;
        }
        
        public List<Organization> Get()
        {
            return db.Organizations.ToList();
        }

        public void Add(Organization organization)
        {
            db.Organizations.Add(organization);
            db.SaveChanges();
        }

        public void Update(Organization organization)
        {
            db.Organizations.Update(organization);
            db.SaveChanges();
        }

        public void Remove(Organization organization)
        {
            db.Organizations.Remove(organization);
            db.SaveChanges();
        }
    }
}