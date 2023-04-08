using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("expenses")]
    public class ExpenseController : Controller
    {
        private IExpenseRepository expenseService;

        public ExpenseController(IExpenseRepository _expenseService)
        {
            expenseService = _expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> Get()
        {
            return await expenseService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> Add(Expense expense)
        {
            await expenseService.Add(expense);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Expense>> Update(Expense expense)
        {
            await expenseService.Update(expense);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Expense>> Remove(Expense expense)
        {
            await expenseService.Remove(expense);

            return NoContent();
        }
    }
}
