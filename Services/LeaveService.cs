using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class LeaveService : ILeaveService
{
    private readonly InMemoryDataStore _store;
    public LeaveService(InMemoryDataStore store) => _store = store;

    public Task<List<LeaveRequest>> GetAllAsync() =>
        Task.FromResult(_store.LeaveRequests.OrderByDescending(l => l.StartDate).ToList());

    public Task<List<LeaveRequest>> GetByEmployeeIdAsync(int employeeId) =>
        Task.FromResult(_store.LeaveRequests.Where(l => l.EmployeeId == employeeId)
            .OrderByDescending(l => l.StartDate).ToList());

    public Task<bool> ApproveAsync(int id)
    {
        var leave = _store.LeaveRequests.FirstOrDefault(l => l.Id == id);
        if (leave is null) return Task.FromResult(false);
        leave.Status = LeaveStatus.Approved;
        return Task.FromResult(true);
    }

    public Task<bool> RejectAsync(int id)
    {
        var leave = _store.LeaveRequests.FirstOrDefault(l => l.Id == id);
        if (leave is null) return Task.FromResult(false);
        leave.Status = LeaveStatus.Rejected;
        return Task.FromResult(true);
    }
}
