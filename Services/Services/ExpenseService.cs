using System.Collections.Generic;
using System.Linq;
using DB.DB_Context;
using DB.Models;
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
        
        public List<Expense> Get()
        {
            return db.Expenses.ToList();
        }

        public void Add(Expense expense)
        {
            db.Expenses.Add(expense);
            db.SaveChanges();
        }

        public void Update(Expense expense)
        {
            db.Expenses.Update(expense);
            db.SaveChanges();
        }

        public void Remove(Expense expense)
        {
            db.Expenses.Remove(expense);
            db.SaveChanges();
        }
    }
}