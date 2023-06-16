using DB.Models;

namespace Services.Interfaces
{
    public interface IAdvertisementRepository
    {
        public Task<List<Advertisement>> Get();

        public Task<Advertisement> GetById(int id);

        public Task<List<Advertisement>> GetByVolonteerName(string username);

        public Task<List<Photo>> GetPhotoes(int id);

        public Task Add(Advertisement advertisement);

        public Task Update(Advertisement advertisement);

        public Task<bool> CreateTransaction(string Username, double Amount, int adId);

        public Task Remove(Advertisement advertisement);
    }
}