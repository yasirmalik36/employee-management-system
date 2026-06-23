namespace EmployeeManagementSystem.Models;

public class Employee
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public string RoleTitle { get; set; } = string.Empty;
    public int? ReportingManagerId { get; set; }
    public string? ReportingManagerName { get; set; }
    public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public DateTime DateOfBirth { get; set; }
    public DateTime JoiningDate { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string Location { get; set; } = "New York, USA";
    public string About { get; set; } = string.Empty;
    public List<string> Skills { get; set; } = new();
    public double PerformanceRating { get; set; }
    public int AnnualLeaveBalance { get; set; } = 12;
    public int SickLeaveBalance { get; set; } = 6;
    public int CasualLeaveBalance { get; set; } = 2;
    public string Gender { get; set; } = "Male";
}
