using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly SampleAppContext context;

        public OfficeController(SampleAppContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Office> Get(string searchPattern)
            // to avoid additional allocations
            => context.Query<Office>($@"select * from Offices where lower(Address) like lower('%{searchPattern}%')");       
            
    }
}
