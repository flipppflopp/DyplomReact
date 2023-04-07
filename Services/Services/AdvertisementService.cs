using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
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
        
        public List<Advertisement> Get()
        {
            return db.Advertisements.ToList();
        }

        public void Add(Advertisement advertisement)
        {
            db.Advertisements.Add(advertisement);
            db.SaveChanges();
        }

        public void Update(Advertisement advertisement)
        {
            db.Advertisements.Update(advertisement);
            db.SaveChanges();
        }

        public void Remove(Advertisement advertisement)
        {
            db.Advertisements.Remove(advertisement);
            db.SaveChanges();
        }
    }
}