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

    public class UserManager : IUserManager
    {
        private readonly IDataAccess _um;



        public UserManager(IDataAccess um)
        {
            _um = um;
        }



        public async Task<bool> AddAsync(User user)
        {
            try
            {
                if (user != null)
                {
                    // Create a temporary driver object with the provided data
                    User tempUser = new User
                    {
                        User_id = user.User_id,
                        User_name = user.User_name,
                        User_mailid = user.User_mailid,
                        User_password = user.User_password
                    };



                    // Add the temporary driver to the data access layer and save changes
                    _um.Users.Addsync(tempUser);
                    await _um.SaveAsync();



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



        public async Task<IEnumerable<User>> getAllAsync()
        {
            // Retrieve all Departments from the data access layer
            return await _um.Users.GetAllAsync();
        }



        public async Task<IEnumerable<User>> getByIdAsync(int id)
        {
            // Retrieve an driver with the specified ID from the data access layer
            var user = await _um.Users.GetFirstorDefaultAsync(t => t.User_id == id);



            // Return the driver if found, otherwise return an empty list
            return user != null ? new List<User> { user } : Enumerable.Empty<User>();
        }
        public async Task Remove(int id)
        {
            // Retrieve the driver with the specified ID from the data access layer
            var user = await _um.Users.GetFirstorDefaultAsync(t => t.User_id == id);



            if (user != null)
            {
                // Remove the driver from the data access layer and save changes
                _um.Users.Remove(user);
                _um.Save();
            }
        }



        public async Task UpdateExisting(User user)
        {
            // Update the existing driver in the data access layer and save changes
            _um.Users.updateExisting(user);
            await _um.SaveAsync();
        }
    }
}

