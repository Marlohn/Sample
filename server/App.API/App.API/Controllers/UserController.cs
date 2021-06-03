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
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get(string officeIds)
        {
            var ids = officeIds
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => Guid.Parse(o))
                .ToArray();

            var users = this.userService.GetUsers()
                .Where(o => ids.Contains(o.Office.Id))
                .ToArray();

            var roles = this.userService
                .GetUserRoles(users.Select(o => o.Id).ToArray());

            try
            {
                foreach (var role in roles)
                {
                    var user = users.FirstOrDefault(o => o.Id == role.UserId);
                    if (user is null)
                    {
                        continue;
                    }

                    if (user.Roles is null)
                    {
                        user.Roles = new List<UserRole>();
                    }

                    user.Roles.Add(role);
                }
            }
            catch
            {

            }

            return users;
        }
    }
}
