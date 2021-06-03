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

        private User[] GetUsers()
        {
            return context.Users
                .Include(o => o.Office)
                .AsNoTracking() // for perfomance
                .ToArray();
        }

        private UserRole[] GetUserRoles(Guid[] userIds)
        {
            return context.UserRoles
                .Include(o => o.Role)
                .AsNoTracking() // for perfomance
                .ToArray();
        }

        public async Task<IEnumerable<User>> GetUsersByOffices(string officeIds)
        {
            var ids = officeIds.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(o => Guid.Parse(o)).ToArray();

            var users = await context.Users
                                    .Include(o => o.Office)
                                    .Where(o => ids.Contains(o.Office.Id))
                                    .AsNoTracking()
                                    .ToArrayAsync();

            //var roles = await GetUserRoles(users.Select(o => o.Id).ToArray());
            var roles = await context.UserRoles
                .Include(o => o.Role)
                .AsNoTracking()
                .ToArrayAsync();

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

            return users;
        }
    }
}
