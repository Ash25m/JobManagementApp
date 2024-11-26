using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public interface IDepartmentService
    {
        Task<Department> CreateDepartment(CreateDepartmentDto department);
        Task<Department> UpdateDepartment(int id, CreateDepartmentDto department);
        Task<List<Department>> GetDepartments();
    }
}
