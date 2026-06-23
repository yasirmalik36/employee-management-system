using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class AttendanceService : IAttendanceService
{
    private readonly InMemoryDataStore _store;
    public AttendanceService(InMemoryDataStore store) => _store = store;

    public Task<List<Attendance>> GetAllAsync() =>
        Task.FromResult(_store.Attendances.OrderByDescending(a => a.Date).ToList());

    public Task<List<Attendance>> GetByEmployeeIdAsync(int employeeId) =>
        Task.FromResult(_store.Attendances.Where(a => a.EmployeeId == employeeId)
            .OrderByDescending(a => a.Date).ToList());
}
