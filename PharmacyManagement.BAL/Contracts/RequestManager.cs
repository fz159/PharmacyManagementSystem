using PharmacyManagement.BAL.Services;
using PharmacyManagement.DAL.DataAccess.Interface;
using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Contracts
{

    public class RequestManager : IRequestManager
    {
        private readonly IDataAccess _rm;



        public RequestManager(IDataAccess rm)
        {
            _rm = rm;
        }



        public async Task<bool> AddAsync(Request request)
        {
            try
            {
                if (request != null)
                {
                    // Create a temporary driver object with the provided data
                    Request tempRequest = new Request
                    {
                        Request_id = request.Request_id,
                        Medicine_name = request.Medicine_name,
                        Medicine_type = request.Medicine_type,
                        Quantity = request.Quantity,
                        
                    };



                    // Add the temporary driver to the data access layer and save changes
                    _rm.Requests.Addsync(tempRequest);
                    await _rm.SaveAsync();



                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }



        }



        public async Task<IEnumerable<Request>> getAllAsync()
        {
            // Retrieve all Departments from the data access layer
            return await _rm.Requests.GetAllAsync();
        }



        public async Task<IEnumerable<Request>> getByIdAsync(int id)
        {
            // Retrieve an driver with the specified ID from the data access layer
            var request = await _rm.Requests.GetFirstorDefaultAsync(t => t.Request_id == id);



            // Return the driver if found, otherwise return an empty list
            return request != null ? new List<Request> { request } : Enumerable.Empty<Request>();
        }
        public async Task Remove(int id)
        {
            // Retrieve the driver with the specified ID from the data access layer
            var request = await _rm.Requests.GetFirstorDefaultAsync(t => t.Request_id == id);



            if (request != null)
            {
                // Remove the driver from the data access layer and save changes
                _rm.Requests.Remove(request);
                _rm.Save();
            }
        }



        public async Task UpdateExisting(Request request)
        {
            // Update the existing driver in the data access layer and save changes
            _rm.Requests.updateExisting(request);
            await _rm.SaveAsync();
        }
    }
}

