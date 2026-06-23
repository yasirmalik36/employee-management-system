using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IPerformanceService
{
    Task<List<PerformanceReview>> GetAllAsync();
    Task<PerformanceReview?> GetByEmployeeIdAsync(int employeeId);
}
