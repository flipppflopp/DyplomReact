using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IVolonteerInfoRepository
    {
        public Task<List<VolonteerInfo>> Get();

        public Task Add(VolonteerInfo info);

        public Task Update(VolonteerInfo info);

        public Task Remove(VolonteerInfo info);
    }
}