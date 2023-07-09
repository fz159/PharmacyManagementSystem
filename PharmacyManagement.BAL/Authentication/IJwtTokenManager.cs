using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Authentication
{
    public interface IJwtTokenManager
    {
        string GenerateToken(Admin admin);
        bool ValidateToken(string token);
        string GenerateToken(User user);
    }
}
