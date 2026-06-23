using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class PerformanceService : IPerformanceService
{
    private readonly InMemoryDataStore _store;
    public PerformanceService(InMemoryDataStore store) => _store = store;

    public Task<List<PerformanceReview>> GetAllAsync() =>
        Task.FromResult(_store.PerformanceReviews.OrderBy(p => p.EmployeeName).ToList());

    public Task<PerformanceReview?> GetByEmployeeIdAsync(int employeeId) =>
        Task.FromResult(_store.PerformanceReviews.FirstOrDefault(p => p.EmployeeId == employeeId));
}
