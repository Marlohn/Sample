using App.API.Models;
using App.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(string officeIds)
        {
            try
            {
                //CAN IMPLEMENT CACHE HERE
                return Ok(await userService.GetUsersByOffices(officeIds));
            }
            catch
            {
                //CAN IMPLEMENT LOG HERE
                return StatusCode(500, "Error example");
            }
        }
    }
}
