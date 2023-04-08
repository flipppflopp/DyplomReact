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
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : Controller
    {

        private IUserRepository userService;

        public AdminsController(IUserRepository _userService)
        {
            userService = _userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await userService.GetAdmins();
        }

        [HttpGet]
        [Route("status/{username}")]
        public async Task<ActionResult<bool>> GetStatus(string username)
        {
            return await userService.GetStatus(username);
        }
    }
}
