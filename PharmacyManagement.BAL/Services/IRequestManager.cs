using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Services
{
    public interface IRequestManager
    {
        // Retrieve all depart asynchronously
        Task<IEnumerable<Request>> getAllAsync();



        // Retrieve depart with the specified ID asynchronously
        Task<IEnumerable<Request>> getByIdAsync(int id);



        // Add a new depart asynchronously
        Task<bool> AddAsync(Request request);



        // Update existing depart asynchronously
        Task UpdateExisting(Request request);



        // Remove an depart with the specified ID asynchronously
        Task Remove(int id);
    }
}
