using Microsoft.EntityFrameworkCore;
using TeknorixJobApi.Data;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateDepartment(CreateDepartmentDto department)
        {
            var newDepartment = new Department
            {
                Title = department.Title,
            };
            _context.Departments.Add(newDepartment);
              await _context.SaveChangesAsync();

            return newDepartment;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var departments= _context.Departments.ToList();
            return departments;
        }

        public async Task<Department> UpdateDepartment(int id, CreateDepartmentDto updatedDepartment)
        {
            var departmentToUpdate= _context.Departments.FirstOrDefault(x => x.Id == id);
            if (departmentToUpdate is null)
                return null;

            departmentToUpdate.Title = updatedDepartment.Title;
            await _context.SaveChangesAsync();
            return departmentToUpdate;
        }
    }
}
