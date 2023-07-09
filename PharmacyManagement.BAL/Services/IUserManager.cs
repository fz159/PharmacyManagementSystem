using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Services
{
    public interface IUserManager
    {
        // Retrieve all depart asynchronously
        Task<IEnumerable<User>> getAllAsync();



        // Retrieve depart with the specified ID asynchronously
        Task<IEnumerable<User>> getByIdAsync(int id);



        // Add a new depart asynchronously
        Task<bool> AddAsync(User user);



        // Update existing depart asynchronously
        Task UpdateExisting(User user);



        // Remove an depart with the specified ID asynchronously
        Task Remove(int id);
    }
}
