﻿using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly SampleAppContext context;

        public OfficeService(SampleAppContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Office>> GetOfficesByAdress(string searchPattern)
        {
            return await context.Offices
                .Where(a => a.Address.ToLower().Contains(searchPattern.ToLower()))
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}
