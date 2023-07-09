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

    public class MedicineManager : IMedicineManager
    {
        private readonly IDataAccess _um;



        public MedicineManager(IDataAccess um)
        {
            _um = um;
        }



        public async Task<bool> AddAsync(Medicine medicine)
        {
            try
            {
                if (medicine != null)
                {
                    // Create a temporary driver object with the provided data
                    Medicine tempMedicine = new Medicine
                    {
                        Medicine_id = medicine.Medicine_id,
                        Medicine_name = medicine.Medicine_name,
                        Medicine_type = medicine.Medicine_type,
                        Price = medicine.Price,
                        Quantity = medicine.Quantity
                    };



                    // Add the temporary driver to the data access layer and save changes
                    _um.Medicines.Addsync(tempMedicine);
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



        public async Task<IEnumerable<Medicine>> GetAllAsync()
        {
            // Retrieve all Departments from the data access layer
            return await _um.Medicines.GetAllAsync();
        }

        public async Task<IEnumerable<Medicine>> GetByIdAsync(int id)
        {
            // Retrieve an driver with the specified ID from the data access layer
            var medicine = await _um.Medicines.GetFirstorDefaultAsync(t => t.Medicine_id == id);



            // Return the driver if found, otherwise return an empty list
            return medicine != null ? new List<Medicine> { medicine } : Enumerable.Empty<Medicine>();
        }

        
        public async Task Remove(int id)
        {
            // Retrieve the driver with the specified ID from the data access layer
            var medicine = await _um.Medicines.GetFirstorDefaultAsync(t => t.Medicine_id == id);



            if (medicine != null)
            {
                // Remove the driver from the data access layer and save changes
                _um.Medicines.Remove(medicine);
                _um.Save();
            }
        }



        public async Task UpdateExisting(Medicine medicine)
        {
            // Update the existing driver in the data access layer and save changes
            _um.Medicines.updateExisting(medicine);
            await _um.SaveAsync();
        }
    }
}

