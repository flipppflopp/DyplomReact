using System.Collections.Generic;
using DB.Models;

namespace Services.Interfaces
{
    public interface IExpenseRepository
    {
        public List<Expense> Get();

        public void Add(Expense expense);

        public void Update(Expense expense);

        public void Remove(Expense expense);
    }
}