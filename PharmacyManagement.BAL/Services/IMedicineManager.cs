using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Services
{
    public interface IMedicineManager
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<IEnumerable<Medicine>>  GetByIdAsync(int id);
        Task<bool> AddAsync(Medicine medicine);
        Task Remove(int id);
        Task UpdateExisting(Medicine med);
    }
}
