using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<List<Organization>> Get()
        {
            return await db.Organizations.ToListAsync();
        }

        public async Task Add(Organization organization)
        {
            await db.Organizations.AddAsync(organization);
            db.SaveChanges();
        }

        public async Task Update(Organization organization)
        {
            db.Organizations.Update(organization);
            await db.SaveChangesAsync();
        }

        public async Task Remove(Organization organization)
        {
            db.Organizations.Remove(organization);
            await db.SaveChangesAsync();
        }
    }
}