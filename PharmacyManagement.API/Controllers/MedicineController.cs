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
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineManager _um;



        public object Transportations { get; private set; }



        public MedicineController(IMedicineManager um)
        {
            _um = um;
        }



        [HttpGet]
        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync()
        {
            return await _um.GetAllAsync();
        }




        [HttpGet("{id}")]
        public Task<IEnumerable<Medicine>> GetById(int id)
        {
            return _um.GetByIdAsync(id);
        }







        [HttpPost]
        public async Task<IActionResult> AddMedicine(Medicine medicine)
        {



            if (await _um.AddAsync(medicine))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Check the input values");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMedicine(int id)
        {
            await _um.Remove(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExisting(int id, Medicine medicine)
        {
            if (id != medicine. Medicine_id)
            {
                return BadRequest("Check the input value");
            }
            await _um.UpdateExisting(medicine);
            return Ok();
        }
    }
}
