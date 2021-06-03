using System;
using System.Collections.Generic;
using System.Linq;
using App.API.Models;
using App.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get(string officeIds)
        {
            try
            {
                return Ok(userService.GetUsersByOffices(officeIds));
            }
            catch
            {
                return StatusCode(500, "Error example");
            }            
        }
    }
}
