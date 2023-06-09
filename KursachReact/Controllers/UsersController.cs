﻿using Microsoft.AspNetCore.Mvc;
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
using Dyplom.Helpers;


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
        [Route("get-balance/{username}")]
        public async Task<ActionResult<double>> GetBalance(string username)
        {
            return userService.GetBalance(username).Result;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return userService.Get().Result;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add([Bind]User user)
        {
            return await userService.Add(user);
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> Validate([Bind]User user)
        {
            return Ok(userService.Validate(user));
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(object user)
        {

            User userTyped = TypeHelper.ObjToType<User>(user);

            await userService.Update(userTyped);

            return NoContent();
        }

        [HttpPut]
        [Route("fill-balance")]
        public async Task<ActionResult> FillBalance(object user_balance)
        {
            Username_Amount usernameAmountTyped = TypeHelper.ObjToType<Username_Amount>(user_balance);

            await userService.FillBalance(usernameAmountTyped.Username, usernameAmountTyped.Amount);

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
