using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeApi.Models;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetDepartmentId(int departmentId)
        {
            var employees = await employeeRepository.GetByDepartmentId(departmentId);
            if (!employees.Any())
            {
                return NoContent();
            }
            return Ok(employees);
        }

        [HttpGet("one/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await employeeRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Employee employee)
        {
            var added = await employeeRepository.Add(employee);

            return CreatedAtRoute("GetById", new { id = added.Id }, added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Fire(int id)
        {
            var result = await employeeRepository.Fire(id);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
