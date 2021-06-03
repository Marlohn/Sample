using App.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetOfficesByAdress(string searchPattern);
    }
}
