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

        public async Task<VolonteerInfo> GetByName(string username)
        {
            var user = await db.Users.SingleAsync(c => c.Name == username);

            return await db.VolonteerInfos.SingleAsync(c => c.UserId == user.Id);
        }

        public async Task<User> GetVolonteerByInfoId(int id)
        {
            var userId = db.VolonteerInfos.Where(c => c.Id == id).Single();
            return await db.Users.Where(c => c.Id == userId.UserId).SingleAsync();
        }

        public async Task<bool> IsSub(string volonteerName, string subName)
        {
            var sub = new User();

            var volonteer = new User();

            try
            {
                sub = await db.Users.SingleAsync(c => c.Name == subName);

                volonteer = await db.Users.SingleAsync(c => c.Name == volonteerName);
            }
            catch (Exception ex)
            {
                return false;
            }

            return db.Subscriptions.Any(c => c.UserID == sub.Id && c.VolonteerID == volonteer.Id);
        }

        public async Task Add(VolonteerInfo info)
        {
            db.VolonteerInfos.Add(info);
            await db.SaveChangesAsync();
        }

        public async Task<bool> AddSubscriber(string subName, string volonteerName)
        {

            if(IsSub(subName, volonteerName).Result == true) 
            {
                return false;
            }
            else
            {
                var sub = await db.Users.SingleAsync(c => c.Name == subName);

                var volonteer = await db.Users.SingleAsync(c => c.Name == volonteerName);


                db.Subscriptions.Add(new Subscription { UserID = sub.Id, VolonteerID = volonteer.Id });
                db.SaveChanges();

                return true;
            }
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

        public async Task<List<User>> GetVolonteers(string username)
        {
            var volonteerInfoes = new List<VolonteerInfo>();

            if (username != "null")
            {
                var user = db.Users.Single(c => c.Name == username);

                var subs = db.Subscriptions.Where(c => c.UserID == user.Id).ToList();

                var viIDs = new List<int>();

                foreach (var sub in subs)
                {
                    viIDs.Add(sub.VolonteerID);
                }

                volonteerInfoes = db.VolonteerInfos.Where(c => viIDs.Contains(c.Id)).ToList();
            }
            else
            {
                volonteerInfoes = db.VolonteerInfos.ToList();
            }

            var userIDs = new List<int>();
            foreach(var vi in volonteerInfoes)
            {
                userIDs.Add(vi.UserId);
            }

            var volonteers = db.Users.Where(c => userIDs.Contains(c.Id));

            foreach (var volonteer in volonteers)
            {
                volonteer.Token = "";
                volonteer.IsAdmin = false;
                volonteer.Password = "";
                volonteer.Balance = 0;
            }

            return volonteers.ToList();
        }
    }
}