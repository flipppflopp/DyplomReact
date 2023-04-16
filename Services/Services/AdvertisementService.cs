using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class AdvertisementService : IAdvertisementRepository
    {
        private readonly ApplicationContext db;
        
        public AdvertisementService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<Advertisement>> Get()
        {
            return await db.Advertisements.ToListAsync();
        }

        public async Task Add(Advertisement advertisement)
        {
            await db.Advertisements.AddAsync(advertisement);
            db.SaveChanges();
        }

        public async Task Update(Advertisement advertisement)
        {
            db.Advertisements.Update(advertisement);
            await db.SaveChangesAsync();
        }

        public async Task Remove(Advertisement advertisement)
        {
            db.Advertisements.Remove(advertisement);
            await db.SaveChangesAsync();
        }
    }
}