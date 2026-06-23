namespace EmployeeManagementSystem.DTOs;

public class ReportSummaryDto
{
    public int TotalEmployees { get; set; }
    public int ActiveEmployees { get; set; }
    public int NewHires { get; set; }
    public double AttritionRate { get; set; }
}

public class GenderDistributionDto
{
    public string Gender { get; set; } = string.Empty;
    public int Count { get; set; }
    public double Percentage { get; set; }
}
