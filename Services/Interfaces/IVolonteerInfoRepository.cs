using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IVolonteerInfoRepository
    {
        public Task<List<VolonteerInfo>> Get();

        public Task<List<User>> GetVolonteers(string username);

        public Task<User> GetVolonteerByInfoId(int id);

        public Task Add(VolonteerInfo info);

        public Task Update(VolonteerInfo info);

        public Task Remove(VolonteerInfo info);
    }
}