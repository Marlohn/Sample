﻿using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Services
{
    public interface IOfficeService
    {

    }

    public class OfficeService : IOfficeService
    {
        private readonly SampleAppContext context;

        public OfficeService(SampleAppContext context)
        {
            this.context = context;
        }

        private IEnumerable<Office> GetOffices()
        {
            return context.Offices
                .AsNoTracking() // for perfomance
                .ToArray();
        }
    }
}