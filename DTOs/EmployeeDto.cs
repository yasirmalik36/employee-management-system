using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.DTOs;

public class EmployeeListDto
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string RoleTitle { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public EmployeeStatus Status { get; set; }
}

public class EmployeeDetailsDto
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string RoleTitle { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public List<string> Skills { get; set; } = new();
    public double PerformanceRating { get; set; }
    public EmployeeStatus Status { get; set; }
    public DateTime JoiningDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int AnnualLeaveBalance { get; set; }
    public int SickLeaveBalance { get; set; }
    public int CasualLeaveBalance { get; set; }
}

public class EmployeeCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public int? ReportingManagerId { get; set; }
    public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-25);
    public DateTime JoiningDate { get; set; } = DateTime.Today;
    public string? ProfilePictureFileName { get; set; }
}
