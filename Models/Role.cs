namespace EmployeeManagementSystem.Models;

public class Role
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int DepartmentId { get; set; }
    public int EmployeeCount { get; set; }
}
