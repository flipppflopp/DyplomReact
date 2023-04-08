using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<List<Expense>> Get();

        public Task Add(Expense expense);

        public Task Update(Expense expense);

        public Task Remove(Expense expense);
    }
}