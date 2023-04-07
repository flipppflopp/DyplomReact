using System.Collections.Generic;
using System.Runtime.InteropServices;
using DB.Models;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        public List<User> Get();
        public void Add(User user);

        public bool Validate(User user);

        public void Update(User user);
        
        public void Remove(User user);
    }
}