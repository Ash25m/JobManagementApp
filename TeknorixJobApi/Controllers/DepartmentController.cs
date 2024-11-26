using Microsoft.AspNetCore.Mvc;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;
using TeknorixJobApi.Service;

namespace TeknorixJobApi.Controllers
{

    [ApiController]
    [Route("api/v1/departments")]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto department)
        {
            var createdDepartment= await _departmentService.CreateDepartment(department);
             return Ok(createdDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] CreateDepartmentDto department)
        {
            var createdDepartment = await _departmentService.UpdateDepartment(id,department);
            return Ok(createdDepartment);
        }


        [HttpGet]

        public async Task<IActionResult> GetDepartments()
        {
            var departments=await _departmentService.GetDepartments();
            return Ok(departments);
        }
    }
}
