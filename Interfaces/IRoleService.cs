using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IRoleService
{
    Task<List<Role>> GetAllAsync();
    Task<Role> CreateAsync(Role role);
    Task<bool> UpdateAsync(Role role);
    Task<bool> DeleteAsync(int id);
}
