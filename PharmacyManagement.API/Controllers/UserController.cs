using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : ControllerBase
    {

        private readonly IUserManager _um;



        public object Transportations { get; private set; }



        public UserController(IUserManager um)
        {
            _um = um;
        }



        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _um.getAllAsync();
        }




        [HttpGet("{id}")]
        public Task<IEnumerable<User>> GetById(int id)
        {
            return _um.getByIdAsync(id);
        }







        [HttpPost]
        public async Task<IActionResult> AddAdmin(User user)
        {



            if (await _um.AddAsync(user))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Check the input values");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int UserId)
        {
            await _um.Remove(UserId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.User_id)
            {
                return BadRequest("Check the input value");
            }
            await _um.UpdateExisting(user);
            return Ok();
        }
    }
}
