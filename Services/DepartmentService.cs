using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class DepartmentService : IDepartmentService
{
    private readonly InMemoryDataStore _store;
    public DepartmentService(InMemoryDataStore store) => _store = store;

    public Task<List<Department>> GetAllAsync() =>
        Task.FromResult(_store.Departments.OrderBy(d => d.Id).ToList());

    public Task<Department> CreateAsync(Department department)
    {
        department.Id = _store.Departments.Count == 0 ? 1 : _store.Departments.Max(d => d.Id) + 1;
        _store.Departments.Add(department);
        return Task.FromResult(department);
    }

    public Task<bool> UpdateAsync(Department department)
    {
        var existing = _store.Departments.FirstOrDefault(d => d.Id == department.Id);
        if (existing is null) return Task.FromResult(false);
        existing.Name = department.Name;
        existing.Description = department.Description;
        existing.ColorHex = department.ColorHex;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var existing = _store.Departments.FirstOrDefault(d => d.Id == id);
        if (existing is null) return Task.FromResult(false);
        _store.Departments.Remove(existing);
        return Task.FromResult(true);
    }
}
