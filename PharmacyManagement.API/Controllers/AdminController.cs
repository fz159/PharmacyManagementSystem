using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement.BAL.Authentication;
using PharmacyManagement.BAL.Services;
using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        
        private readonly IAdminManager _am;

        private readonly IJwtTokenManager _jwtTokenManager;

        public object Transportations { get; private set; }

        public AdminController(IAdminManager am, IJwtTokenManager JwtTokenManager)
        {
            _am = am;
            _jwtTokenManager = JwtTokenManager;
        }

        public AdminController(IAdminManager am)
        {
            _am = am;
        }

        //login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Admin admin)
        {
            // TODO: validate username and password



            var token = _jwtTokenManager.GenerateToken(admin);
            return Ok(new { token });
        }



        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var AdminId = int.Parse(User.FindFirst("id").Value);
            // TODO: get manager from database using managerId



            return Ok(new
            {
                Id = AdminId,
                Email = User.FindFirst("Admin_mailid").Value,
                Name = User.FindFirst("Admin_name").Value
            });
        }


        [HttpGet]
        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _am.getAllAsync();
        }




        [HttpGet("{id}")]
        public Task<IEnumerable<Admin>> GetById(int id)
        {
            return _am.getByIdAsync(id);
        }







        [HttpPost]
        public async Task<IActionResult> AddAdmin(Admin admin)
        {



            if (await _am.AddAsync(admin))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Check the input values");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAdmin(int AdminId)
        {
            await _am.Remove(AdminId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.Admin_id)
            {
                return BadRequest("Check the input value");
            }
            await _am.UpdateExisting(admin);
            return Ok();
        }
    }
}
