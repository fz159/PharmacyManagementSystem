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
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackManager _fc;



        public object Feedbacks { get; private set; }



        public FeedbackController(IFeedbackManager fc)
        {
            _fc = fc;
        }



        [HttpGet]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _fc.GetAllAsync();
        }




        [HttpGet("{id}")]
        public Task<IEnumerable<Feedback>> GetById(int id)
        {
            return _fc.GetByIdAsync(id);
        }







        [HttpPost]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
        {



            if (await _fc.AddAsync(feedback))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Check the input values");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeedback(int FeedbackId)
        {
            await _fc.Remove(FeedbackId);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeedback(int id, Feedback feedback)
        {
            if (id != feedback.Feedback_id)
            {
                return BadRequest("Check the input value");
            }
            await _fc.UpdateExisting(feedback);
            return Ok();
        }
    }
}
