using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class OrganizationMemberService : IOrganizationMemberRepository
    {
        private readonly ApplicationContext db;
        
        public OrganizationMemberService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<OrganizationMember>> Get()
        {
            return await db.OrganizationMembers.ToListAsync();
        }

        public async Task Add(OrganizationMember organizationMember)
        {
            await db.OrganizationMembers.AddAsync(organizationMember);
            db.SaveChanges();
        }

        public async Task Update(OrganizationMember organizationMember)
        {
            db.OrganizationMembers.Update(organizationMember);
            await db.SaveChangesAsync();
        }

        public async Task Remove(OrganizationMember organizationMember)
        {
            db.OrganizationMembers.Remove(organizationMember);
            await db.SaveChangesAsync();
        }
    }
}