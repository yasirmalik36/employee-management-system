namespace EmployeeManagementSystem.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int EmployeeCount { get; set; }
    public string ColorHex { get; set; } = "#594AE2";
}
