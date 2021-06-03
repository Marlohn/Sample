using App.API.Models;
using App.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService officeService;

        public OfficeController(IOfficeService officeService)
        {
            this.officeService = officeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> Get(string searchPattern)
        {
            try
            {
                //CAN IMPLEMENT CACHE HERE
                return Ok(await officeService.GetOfficesByAdress(searchPattern));
            }
            catch (Exception)
            {
                //CAN IMPLEMENT LOG HERE
                return StatusCode(500, "Error example");
            }
        }

    }
}
