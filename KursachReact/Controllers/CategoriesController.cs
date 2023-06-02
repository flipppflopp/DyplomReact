using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Services.Interfaces;
using DB.Models;

namespace KursachReact.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {

        private ICategoryRepository categoryService;

        public CategoryController(ICategoryRepository _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await categoryService.Get();
        }

    }
}
