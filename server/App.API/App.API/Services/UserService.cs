using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using Microsoft.EntityFrameworkCore;

namespace App.API.Services
{
    public class UserService : IUserService
    {
        private readonly SampleAppContext context;
        public UserService(SampleAppContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetUsersByOffices(string officeIds)
        {
            var ids = officeIds.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(o => Guid.Parse(o)).ToArray();
            return await context.Users.Include(o => o.Office)
                                      .Where(o => ids.Contains(o.Office.Id))
                                      .AsNoTracking()
                                      .ToArrayAsync();
        }
    }
}
