namespace EmployeeManagementSystem.DTOs;

public class DashboardKpiDto
{
    public int TotalEmployees { get; set; }
    public int TotalDepartments { get; set; }
    public int PresentToday { get; set; }
    public int OnLeaveToday { get; set; }
}

public class MonthlyTrendDto
{
    public string Month { get; set; } = string.Empty;
    public int EmployeeCount { get; set; }
}

public class DepartmentShareDto
{
    public string DepartmentName { get; set; } = string.Empty;
    public int Count { get; set; }
    public double Percentage { get; set; }
}

public class RecentHireDto
{
    public string FullName { get; set; } = string.Empty;
    public string RoleTitle { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
}

public class UpcomingBirthdayDto
{
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
}
