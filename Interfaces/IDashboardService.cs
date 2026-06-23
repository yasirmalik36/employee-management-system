using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Interfaces;

public interface IDashboardService
{
    Task<DashboardKpiDto> GetKpisAsync();
    Task<List<MonthlyTrendDto>> GetMonthlyTrendAsync();
    Task<List<DepartmentShareDto>> GetDepartmentShareAsync();
    Task<List<RecentHireDto>> GetRecentHiresAsync();
    Task<List<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync();
    Task<ReportSummaryDto> GetReportSummaryAsync();
    Task<List<GenderDistributionDto>> GetGenderDistributionAsync();
}
