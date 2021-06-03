using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using App.API.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return Ok(await officeService.GetOfficesByAdress(searchPattern));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error example");
            }            
        }  
            
    }
}
