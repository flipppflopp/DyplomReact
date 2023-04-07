using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IAdvertisementRepository
    {
        public List<Advertisement> Get();

        public void Add(Advertisement advertisement);

        public void Update(Advertisement advertisement);

        public void Remove(Advertisement advertisement);
    }
}