using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IVolonteerInfoRepository
    {
        public Task<List<VolonteerInfo>> Get();

        public Task<VolonteerInfo> GetByName(string username);

        public Task<List<User>> GetVolonteers(string username);

        public Task<bool> IsSub(string volonteerName, string subName);

        public Task<bool> AddSubscriber(string sub, string volonteer);

        public Task<User> GetVolonteerByInfoId(int id);

        public Task Add(VolonteerInfo info);

        public Task Update(VolonteerInfo info);

        public Task Remove(VolonteerInfo info);
    }
}