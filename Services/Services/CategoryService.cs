using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationContext db;
        
        public CategoryService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<Category>> Get()
        {
            return await db.Categories.ToListAsync();
        }
    }
}