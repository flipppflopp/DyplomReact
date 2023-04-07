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
        /* ApplicationContext db;

        public UsersController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Set<User>().ToListAsync();
        }
            
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAccount([Bind] User user)
        {
            if (db.Users.Any(c => c.Name == user.Name))
            {
                return Ok(false);
            }
            
            
            User userDb = new User
            {
                Name = user.Name,
                Password = user.Password
            };
            
            db.Users.Add(userDb);
            db.SaveChanges();
            return Ok(true);
        }

        [HttpGet]
        [Route("validate/{username}_{password}")]
        public async Task<IActionResult> Validate(string username,string password)
        {
            return Ok(db.Users.Any(c => c.Name == username && c.Password == password));
        }
        
        
        [HttpGet]
        [Route("getUserId/{username}")]
        public async Task<IActionResult> GetId(string username)
        {
            return Ok(db.Users.Where(c => c.Name == username).FirstOrDefault().Id);
        }
        
        
        [HttpPost]
        [Route("editProfile")]
        public async Task<IActionResult> EditAccount([Bind] User user)
        {
            User userDb = db.Users.Where(c => c.Name == user.Name).FirstOrDefault();
            userDb.Password = user.Password;
            db.SaveChanges();
            
            return Ok(true);
        }
        
        
        [HttpGet]
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            db.Users.Remove(db.Users.Where(c => c.Id == id).FirstOrDefault());
            db.SaveChanges();
            return Ok(db.Users.ToList());
        }
        */



        private IUserRepository userService;

        public UsersController(IUserRepository _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return userService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add([Bind]User user)
        {
            userService.Add(user);

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
            userService.Update(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Remove(User user)
        {
            userService.Remove(user);

            return NoContent();
        }
    }
}
