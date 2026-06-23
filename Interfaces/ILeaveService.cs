using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface ILeaveService
{
    Task<List<LeaveRequest>> GetAllAsync();
    Task<List<LeaveRequest>> GetByEmployeeIdAsync(int employeeId);
    Task<bool> ApproveAsync(int id);
    Task<bool> RejectAsync(int id);
}
