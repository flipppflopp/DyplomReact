using System.Collections.Generic;
using System.Runtime.InteropServices;
using DB.Models;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> Get();
        public Task<string> Add(User user);

        public Task<string> Validate(User user);

        public Task Update(User user);
        
        public Task Remove(User user);

        public Task<List<User>> GetAdmins();

        public Task<bool> GetStatus(string username);

        public Task<bool> CheckToken(User user);

    }
}