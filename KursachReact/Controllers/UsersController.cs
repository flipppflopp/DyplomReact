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
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserRepository userService;

        public UsersController(IUserRepository _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return userService.Get().Result;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add([Bind]User user)
        {
            await userService.Add(user);

            return NoContent();
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> Validate([Bind]User user)
        {
            return Ok(userService.Validate(user));
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            await userService.Update(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Remove(User user)
        {
            await userService.Remove(user);

            return NoContent();
        }
    }
}
