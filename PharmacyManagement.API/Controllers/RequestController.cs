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
    public class RequestController : ControllerBase
    {

        private readonly IRequestManager _um;



        public object Transportations { get; private set; }



        public RequestController(IRequestManager um)
        {
            _um = um;
        }



        [HttpGet]
        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _um.getAllAsync();
        }




        [HttpGet("{id}")]
        public Task<IEnumerable<Request>> GetById(int id)
        {
            return _um.getByIdAsync(id);
        }







        [HttpPost]
        public async Task<IActionResult> AddRequest(Request request)
        {



            if (await _um.AddAsync(request))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Check the input values");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRequest(int RequestId)
        {
            await _um.Remove(RequestId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRequest(int id, Request request)
        {
            if (id != request.Request_id)
            {
                return BadRequest("Check the input value");
            }
            await _um.UpdateExisting(request);
            return Ok();
        }
    }
}
