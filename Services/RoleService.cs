using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class RoleService : IRoleService
{
    private readonly InMemoryDataStore _store;
    public RoleService(InMemoryDataStore store) => _store = store;

    public Task<List<Role>> GetAllAsync() =>
        Task.FromResult(_store.Roles.OrderBy(r => r.Id).ToList());

    public Task<Role> CreateAsync(Role role)
    {
        role.Id = _store.Roles.Count == 0 ? 1 : _store.Roles.Max(r => r.Id) + 1;
        _store.Roles.Add(role);
        return Task.FromResult(role);
    }

    public Task<bool> UpdateAsync(Role role)
    {
        var existing = _store.Roles.FirstOrDefault(r => r.Id == role.Id);
        if (existing is null) return Task.FromResult(false);
        existing.Title = role.Title;
        existing.Description = role.Description;
        existing.DepartmentId = role.DepartmentId;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var existing = _store.Roles.FirstOrDefault(r => r.Id == id);
        if (existing is null) return Task.FromResult(false);
        _store.Roles.Remove(existing);
        return Task.FromResult(true);
    }
}
