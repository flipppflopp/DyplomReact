using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService : IUserRepository
    {
        private readonly ApplicationContext db;

        SymmetricSecurityKey secretKey;
        SigningCredentials signingCredentials;

        Claim[] claims = new[]
        {
                    new Claim(JwtRegisteredClaimNames.Sub, "user_id_here"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

        public UserService(ApplicationContext context)
        {
            db = context;

            secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_key_here_111"));
            signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, "user_id_here"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
        }
        
        public async Task<List<User>> Get()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<double> GetBalance(string username)
        {
            var user = await db.Users.Where(c => c.Name == username).SingleAsync();

            return user.Balance;
        }

        public async Task<string> Add(User user)
        {
            if (!db.Users.Any(c => c.Name == user.Name))
            {
                await db.Users.AddAsync(user);

                db.SaveChanges();


                var token = new JwtSecurityToken(
                    issuer: "issuer_here",
                    audience: "audience_here",
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signingCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }
            else 
            {
                return "";
            }

        }

        public async Task<string> Validate(User user)
        {
            if(db.Users.Any(c => c.Name == user.Name && c.Password == user.Password)) 
            {
                var token = new JwtSecurityToken(
                    issuer: "issuer_here",
                    audience: "audience_here",
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signingCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }

            return "";
        }

        public async Task Update(User user)
        {
            User original = db.Users.Where(c => c.Name == user.Name).Single();
            original.Password = user.Password;
            db.Users.Update(original);
            await db.SaveChangesAsync();
        }

        public async Task FillBalance(string username, double amount)
        {
            User user = await db.Users.Where(c => c.Name == username).SingleAsync();
            user.Balance += amount;
            db.SaveChanges();
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

        public async Task<bool> CheckToken(User user)
        {
            return false;
        }
    }
}