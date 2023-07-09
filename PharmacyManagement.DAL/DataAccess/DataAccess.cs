using PharmacyManagement.DAL.DataAccess.Interface;
using PharmacyManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyMangement.DAL.Data;

namespace PharmacyManagement.DAL.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _db;
        public DataAccess(ApplicationDbContext db)
        {
            _db = db;
            Admins = new AdminRepo(_db);
            Feedbacks = new FeedbackRepo(_db);
            Medicines = new MedicineRepo(_db);
            Requests = new RequestRepo(_db);
            Users = new UserRepo(_db);
        }





        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }



        public void Save()
        {
            _db.SaveChangesAsync();
        }



        public IAdminRepo Admins { get; private set; }
        public IFeedbackRepo Feedbacks { get; private set; }
        public IMedicineRepo Medicines { get; private set; }
        public IRequestRepo Requests { get; private set; }
        public IUserRepo Users { get; private set; }




    }



    public class AdminRepo : Repo<Admin>, IAdminRepo
    {
        private readonly ApplicationDbContext _db;
        public AdminRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _db.Admins
                .Include(c => c.Username_id)
                .ToListAsync();
        }



        public async Task<Admin> GetById(int id)
        {
            return await _db.Admins
                .Include(c => c.Username_id)
                .Where(x => x.Admin_id == id)
                .FirstOrDefaultAsync();
        }

    }
    public class FeedbackRepo : Repo<Feedback>, IFeedbackRepo
    {
        private readonly ApplicationDbContext _db;
        public FeedbackRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

    }
    public class MedicineRepo : Repo<Medicine>, IMedicineRepo
    {
        private readonly ApplicationDbContext _db;
        public MedicineRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
    public class RequestRepo : Repo<Request>, IRequestRepo
    {
        private readonly ApplicationDbContext _db;
        public RequestRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       

    }
    public class UserRepo : Repo<User>, IUserRepo
    {
        private readonly ApplicationDbContext _db;
        public UserRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}