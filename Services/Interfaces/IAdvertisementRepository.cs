using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IAdvertisementRepository
    {
        public Task<List<Advertisement>> Get();

        public Task Add(Advertisement advertisement);

        public Task Update(Advertisement advertisement);

        public Task Remove(Advertisement advertisement);
    }
}