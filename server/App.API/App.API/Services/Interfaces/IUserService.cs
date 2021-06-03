using App.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersByOffices(string officeIds);
    }
}
