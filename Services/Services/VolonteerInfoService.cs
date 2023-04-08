using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class VolonteerInfoService : IVolonteerInfoRepository
    {
        private readonly ApplicationContext db;
        
        public VolonteerInfoService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<VolonteerInfo>> Get()
        {
            return await db.VolonteerInfos.ToListAsync();
        }

        public async Task Add(VolonteerInfo info)
        {
            db.VolonteerInfos.Add(info);
            await db.SaveChangesAsync();
        }

        public async Task Update(VolonteerInfo info)
        {
            db.VolonteerInfos.Update(info);
            await db.SaveChangesAsync();
        }

        public async Task Remove(VolonteerInfo info)
        {
            db.VolonteerInfos.Remove(info);
            await db.SaveChangesAsync();
        }
    }
}