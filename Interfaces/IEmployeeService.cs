using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeListDto>> GetAllAsync();
    Task<EmployeeDetailsDto?> GetDetailsAsync(int id);
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> CreateAsync(EmployeeCreateDto dto);
    Task<bool> UpdateAsync(int id, EmployeeCreateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<Employee>> GetManagersAsync();
}
