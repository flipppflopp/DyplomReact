using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IVolonteerInfoRepository
    {
        public List<VolonteerInfo> Get();

        public void Add(VolonteerInfo info);

        public void Update(VolonteerInfo info);

        public void Remove(VolonteerInfo info);
    }
}