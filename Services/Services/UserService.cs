using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
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
        
        public List<User> Get()
        {
            return db.Users.ToList();
        }
        
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool Validate(User user)
        {
            return db.Users.Any(c => c.Name == user.Name && c.Password == user.Password);
        }

        public void Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
        
        public void Remove(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}