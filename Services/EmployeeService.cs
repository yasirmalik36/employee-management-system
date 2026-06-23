using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class EmployeeService : IEmployeeService
{
    private readonly InMemoryDataStore _store;

    public EmployeeService(InMemoryDataStore store)
    {
        _store = store;
    }

    public Task<List<EmployeeListDto>> GetAllAsync()
    {
        var result = _store.Employees
            .OrderBy(e => e.Id)
            .Select(e => new EmployeeListDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FullName = e.FullName,
                ProfilePictureUrl = e.ProfilePictureUrl,
                DepartmentName = e.DepartmentName,
                RoleTitle = e.RoleTitle,
                Email = e.Email,
                Status = e.Status
            }).ToList();

        return Task.FromResult(result);
    }

    public Task<EmployeeDetailsDto?> GetDetailsAsync(int id)
    {
        var e = _store.Employees.FirstOrDefault(x => x.Id == id);
        if (e is null) return Task.FromResult<EmployeeDetailsDto?>(null);

        var dto = new EmployeeDetailsDto
        {
            Id = e.Id,
            EmployeeCode = e.EmployeeCode,
            FullName = e.FullName,
            Email = e.Email,
            Phone = e.Phone,
            DepartmentName = e.DepartmentName,
            RoleTitle = e.RoleTitle,
            ProfilePictureUrl = e.ProfilePictureUrl,
            Location = e.Location,
            About = e.About,
            Skills = e.Skills,
            PerformanceRating = e.PerformanceRating,
            Status = e.Status,
            JoiningDate = e.JoiningDate,
            DateOfBirth = e.DateOfBirth,
            AnnualLeaveBalance = e.AnnualLeaveBalance,
            SickLeaveBalance = e.SickLeaveBalance,
            CasualLeaveBalance = e.CasualLeaveBalance
        };

        return Task.FromResult<EmployeeDetailsDto?>(dto);
    }

    public Task<Employee?> GetByIdAsync(int id)
    {
        var e = _store.Employees.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(e);
    }

    public Task<Employee> CreateAsync(EmployeeCreateDto dto)
    {
        var dept = _store.Departments.First(d => d.Id == dto.DepartmentId);
        var role = _store.Roles.First(r => r.Id == dto.RoleId);
        var manager = dto.ReportingManagerId.HasValue
            ? _store.Employees.FirstOrDefault(e => e.Id == dto.ReportingManagerId)
            : null;

        var id = _store.GetNextEmployeeId();
        var employee = new Employee
        {
            Id = id,
            EmployeeCode = $"EMP{id:D3}",
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DepartmentId = dept.Id,
            DepartmentName = dept.Name,
            RoleId = role.Id,
            RoleTitle = role.Title,
            ReportingManagerId = manager?.Id,
            ReportingManagerName = manager?.FullName,
            EmploymentType = dto.EmploymentType,
            Status = dto.Status,
            DateOfBirth = dto.DateOfBirth,
            JoiningDate = dto.JoiningDate,
            ProfilePictureUrl = $"https://i.pravatar.cc/150?img={(id % 70) + 1}",
            About = $"New {role.Title} in the {dept.Name} department.",
            Skills = new List<string>()
        };

        _store.Employees.Add(employee);
        dept.EmployeeCount = _store.Employees.Count(e => e.DepartmentId == dept.Id);
        role.EmployeeCount = _store.Employees.Count(e => e.RoleId == role.Id);

        return Task.FromResult(employee);
    }

    public Task<bool> UpdateAsync(int id, EmployeeCreateDto dto)
    {
        var e = _store.Employees.FirstOrDefault(x => x.Id == id);
        if (e is null) return Task.FromResult(false);

        var dept = _store.Departments.First(d => d.Id == dto.DepartmentId);
        var role = _store.Roles.First(r => r.Id == dto.RoleId);
        var manager = dto.ReportingManagerId.HasValue
            ? _store.Employees.FirstOrDefault(m => m.Id == dto.ReportingManagerId)
            : null;

        e.FirstName = dto.FirstName;
        e.LastName = dto.LastName;
        e.Email = dto.Email;
        e.Phone = dto.Phone;
        e.DepartmentId = dept.Id;
        e.DepartmentName = dept.Name;
        e.RoleId = role.Id;
        e.RoleTitle = role.Title;
        e.ReportingManagerId = manager?.Id;
        e.ReportingManagerName = manager?.FullName;
        e.EmploymentType = dto.EmploymentType;
        e.Status = dto.Status;
        e.DateOfBirth = dto.DateOfBirth;
        e.JoiningDate = dto.JoiningDate;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var e = _store.Employees.FirstOrDefault(x => x.Id == id);
        if (e is null) return Task.FromResult(false);
        _store.Employees.Remove(e);
        return Task.FromResult(true);
    }

    public Task<List<Employee>> GetManagersAsync()
    {
        return Task.FromResult(_store.Employees.ToList());
    }
}
