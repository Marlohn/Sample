using App.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersByOffices(string officeIds);
    }
}
