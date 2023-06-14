using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class ExpenseService : IExpenseRepository
    {
        private readonly ApplicationContext db;
        
        public ExpenseService(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<List<Expense>> Get()
        {
            return await db.Expenses.ToListAsync();
        }

        public async Task<List<Expense>> GetExpensesByUser(string username)
        {
            var user = await db.Users.Where(c => c.Name == username).SingleAsync();
            return await db.Expenses.Where(c => c.UserId == user.Id).ToListAsync();
        }

        public async Task Add(Expense expense)
        {
            await db.Expenses.AddAsync(expense);
            db.SaveChanges();
        }

        public async Task Update(Expense expense)
        {
            db.Expenses.Update(expense);
            await db.SaveChangesAsync();
        }

        public async Task Remove(Expense expense)
        {
            db.Expenses.Remove(expense);
            await db.SaveChangesAsync();
        }
    }
}