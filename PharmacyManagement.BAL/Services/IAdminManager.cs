using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Services
{
    public interface IAdminManager
    {
        // Retrieve all depart asynchronously
        Task<IEnumerable<Admin>> getAllAsync();



        // Retrieve depart with the specified ID asynchronously
        Task<IEnumerable<Admin>> getByIdAsync(int id);



        // Add a new depart asynchronously
        Task<bool> AddAsync(Admin admin);



        // Update existing depart asynchronously
        Task UpdateExisting(Admin admin);



        // Remove an depart with the specified ID asynchronously
        Task Remove(int id);
    }
}
