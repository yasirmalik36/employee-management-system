namespace EmployeeManagementSystem.Models;

public class PerformanceGoal
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ProgressPercent { get; set; }
}

public class PerformanceReview
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Month { get; set; } = string.Empty;
    public List<PerformanceGoal> Goals { get; set; } = new();
}
