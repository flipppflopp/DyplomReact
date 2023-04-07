using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
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
        
        public List<OrganizationMember> Get()
        {
            return db.OrganizationMembers.ToList();
        }

        public void Add(OrganizationMember organizationMember)
        {
            db.OrganizationMembers.Add(organizationMember);
            db.SaveChanges();
        }

        public void Update(OrganizationMember organizationMember)
        {
            db.OrganizationMembers.Update(organizationMember);
            db.SaveChanges();
        }

        public void Remove(OrganizationMember organizationMember)
        {
            db.OrganizationMembers.Remove(organizationMember);
            db.SaveChanges();
        }
    }
}