using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService : IUserRepository
    {
        private readonly ApplicationContext db;

        public UserService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<User>> Get()
        {
            return await db.Users.ToListAsync();
        }
        
        public async Task Add(User user)
        {
            await db.Users.AddAsync(user);
            db.SaveChanges();
        }

        public async Task<bool> Validate(User user)
        {
            return db.Users.Any(c => c.Name == user.Name && c.Password == user.Password);
        }

        public async Task Update(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
        
        public async Task Remove(User user)
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAdmins()
        {
            return await db.Users.Where(c => c.IsAdmin == true).ToListAsync();
        }

        public async Task<bool> GetStatus(string username)
        {
            return db.Users.Any(c => c.Name == username && c.IsAdmin == true);
        }
    }
}