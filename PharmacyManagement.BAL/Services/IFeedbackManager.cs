using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Services
{
    public interface IFeedbackManager
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<IEnumerable<Feedback>> GetByIdAsync(int id);
        Task<bool> AddAsync(Feedback feedback);
        Task Remove(int id);
        Task UpdateExisting(Feedback feed);
    }
}
