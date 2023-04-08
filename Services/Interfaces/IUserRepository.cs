using System.Collections.Generic;
using System.Runtime.InteropServices;
using DB.Models;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        public Task<Task<List<User>>> Get();
        public Task Add(User user);

        public Task<bool> Validate(User user);

        public Task Update(User user);
        
        public Task Remove(User user);

        public Task<List<User>> GetAdmins();

        public Task<bool> GetStatus(string username);

    }
}