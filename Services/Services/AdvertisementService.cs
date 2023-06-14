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

        public async Task<Advertisement> GetById(int id)
        {
            return await db.Advertisements.Where(c => c.ID == id).SingleAsync();
        }

        public async Task<List<Photo>> GetPhotoes(int id)
        {
            return await db.Photoes.Where(c => c.AdID == id).ToListAsync();
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

        public async Task<bool> CreateTransaction(string Username, double Amount, int adId)
        {
            try
            {
                var ad = await db.Advertisements.Where(c => c.ID == adId).SingleAsync();
                ad.CollectedSum += Amount;

                var user = await db.Users.Where(c => c.Name == Username).SingleAsync();
                if (user.Balance >= Amount)
                {
                    user.Balance -= Amount;
                }
                else
                {
                    throw new Exception();
                }

                db.Expenses.Add(new Expense
                {
                    Amount = Amount,
                    Date = DateTime.Now,
                    UserId = user.Id,
                    AdId = ad.ID
                });

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task Remove(Advertisement advertisement)
        {
            db.Advertisements.Remove(advertisement);
            await db.SaveChangesAsync();
        }
    }
}