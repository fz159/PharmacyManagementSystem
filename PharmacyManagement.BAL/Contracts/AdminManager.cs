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
    
        public class AdminManager : IAdminManager
        {
            private readonly IDataAccess _da;



            public AdminManager(IDataAccess da)
            {
                _da = da;
            }



            public async Task<bool> AddAsync(Admin admin)
            {
                try
                {
                    if (admin != null)
                    {

                    // Get the agent details from the agents table using the foreign key AgentId
                    User user = await _da.Users.GetFirstorDefaultAsync(x => x.User_id == admin.User_id);
                    
                    
                    // Create a temporary driver object with the provided data
                    Admin tempAdmin = new Admin
                        {
                            Admin_id = admin.Admin_id,
                            Admin_name = admin.Admin_name,
                            Admin_mailid = admin.Admin_mailid,
                            Admin_password = admin.Admin_password,
                            Add_medicine = admin.Add_medicine



                        };



                        // Add the temporary driver to the data access layer and save changes
                        _da.Admins.Addsync(tempAdmin);
                        await _da.SaveAsync();



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



            public async Task<IEnumerable<Admin>> getAllAsync()
            {
                // Retrieve all Departments from the data access layer
                return await _da.Admins.GetAllAsync();
            }



            public async Task<IEnumerable<Admin>> getByIdAsync(int id)
            {
                // Retrieve an driver with the specified ID from the data access layer
                var admin = await _da.Admins.GetFirstorDefaultAsync(t => t.Admin_id == id);



                // Return the driver if found, otherwise return an empty list
                return admin != null ? new List<Admin> { admin } : Enumerable.Empty<Admin>();
            }



            public async Task Remove(int id)
            {
                // Retrieve the driver with the specified ID from the data access layer
                var admin = await _da.Admins.GetFirstorDefaultAsync(t => t.Admin_id == id);



                if (admin != null)
                {
                    // Remove the driver from the data access layer and save changes
                    _da.Admins.Remove(admin);
                    _da.Save();
                }
            }



            public async Task UpdateExisting(Admin admin)
            {
                // Update the existing driver in the data access layer and save changes
                _da.Admins.updateExisting(admin);
                await _da.SaveAsync();
            }
        }
    }

