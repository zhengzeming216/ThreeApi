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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await departmentRepository.GetAll();
            if (!departments.Any())
            {
                return NoContent();
            }

            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Add([FromBody]Department department)
        {
            var added = await departmentRepository.Add(department);

            return Ok(added);
        }
    }
}
