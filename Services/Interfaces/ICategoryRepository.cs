using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> Get();
    }
}