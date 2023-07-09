using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.DataAccess.Interface
{
    public interface IDataAccess
    {
        IUserRepo Users { get; }
        IFeedbackRepo Feedbacks { get; }
        IMedicineRepo Medicines { get; }
        IRequestRepo Requests { get; }
        IAdminRepo Admins { get; }

        

        void Save();
        Task SaveAsync();

    }

    public interface IUserRepo : IRepo<User> { }
    public interface IFeedbackRepo : IRepo<Feedback> {}
    public interface IMedicineRepo : IRepo<Medicine> {}
    public interface IRequestRepo : IRepo<Request> {}
    public interface IAdminRepo : IRepo<Admin>
    {
        
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetById(int id);
    }
}
