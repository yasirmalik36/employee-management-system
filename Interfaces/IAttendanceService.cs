using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IAttendanceService
{
    Task<List<Attendance>> GetAllAsync();
    Task<List<Attendance>> GetByEmployeeIdAsync(int employeeId);
}
