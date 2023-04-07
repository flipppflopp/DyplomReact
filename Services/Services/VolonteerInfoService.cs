using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
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
        
        public List<VolonteerInfo> Get()
        {
            return db.VolonteerInfos.ToList();
        }

        public void Add(VolonteerInfo info)
        {
            db.VolonteerInfos.Add(info);
            db.SaveChanges();
        }

        public void Update(VolonteerInfo info)
        {
            db.VolonteerInfos.Update(info);
            db.SaveChanges();
        }

        public void Remove(VolonteerInfo info)
        {
            db.VolonteerInfos.Remove(info);
            db.SaveChanges();
        }
    }
}