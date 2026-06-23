using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class DashboardService : IDashboardService
{
    private readonly InMemoryDataStore _store;
    public DashboardService(InMemoryDataStore store) => _store = store;

    public Task<DashboardKpiDto> GetKpisAsync()
    {
        var today = DateTime.Today;
        var presentToday = _store.Attendances.Count(a => a.Date == today &&
            (a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late || a.Status == AttendanceStatus.HalfDay));
        var onLeave = _store.Employees.Count(e => e.Status == EmployeeStatus.OnLeave);

        var dto = new DashboardKpiDto
        {
            TotalEmployees = _store.Employees.Count,
            TotalDepartments = _store.Departments.Count,
            PresentToday = presentToday > 0 ? presentToday : (int)(_store.Employees.Count * 0.75),
            OnLeaveToday = onLeave
        };
        return Task.FromResult(dto);
    }

    public Task<List<MonthlyTrendDto>> GetMonthlyTrendAsync()
    {
        var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        var rnd = new Random(99);
        var baseCount = Math.Max(1, _store.Employees.Count - 24);
        var list = new List<MonthlyTrendDto>();
        foreach (var m in months)
        {
            baseCount += rnd.Next(0, 4);
            list.Add(new MonthlyTrendDto { Month = m, EmployeeCount = baseCount });
        }
        return Task.FromResult(list);
    }

    public Task<List<DepartmentShareDto>> GetDepartmentShareAsync()
    {
        var total = _store.Employees.Count;
        var list = _store.Departments.Select(d => new DepartmentShareDto
        {
            DepartmentName = d.Name,
            Count = d.EmployeeCount,
            Percentage = total == 0 ? 0 : Math.Round(d.EmployeeCount * 100.0 / total, 0)
        }).ToList();
        return Task.FromResult(list);
    }

    public Task<List<RecentHireDto>> GetRecentHiresAsync()
    {
        var list = _store.Employees
            .OrderByDescending(e => e.JoiningDate)
            .Take(3)
            .Select(e => new RecentHireDto
            {
                FullName = e.FullName,
                RoleTitle = e.RoleTitle,
                JoiningDate = e.JoiningDate,
                ProfilePictureUrl = e.ProfilePictureUrl
            }).ToList();
        return Task.FromResult(list);
    }

    public Task<List<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync()
    {
        var today = DateTime.Today;
        var list = _store.Employees
            .Select(e => new { e, NextBirthday = NextOccurrence(e.DateOfBirth, today) })
            .OrderBy(x => x.NextBirthday)
            .Take(3)
            .Select(x => new UpcomingBirthdayDto
            {
                FullName = x.e.FullName,
                DateOfBirth = x.e.DateOfBirth,
                ProfilePictureUrl = x.e.ProfilePictureUrl
            }).ToList();
        return Task.FromResult(list);
    }

    public Task<ReportSummaryDto> GetReportSummaryAsync()
    {
        var total = _store.Employees.Count;
        var active = _store.Employees.Count(e => e.Status == EmployeeStatus.Active);
        var newHires = _store.Employees.Count(e => e.JoiningDate >= DateTime.Today.AddMonths(-3));
        var terminated = _store.Employees.Count(e => e.Status == EmployeeStatus.Terminated || e.Status == EmployeeStatus.Inactive);
        var attrition = total == 0 ? 0 : Math.Round(terminated * 100.0 / total, 1);

        var dto = new ReportSummaryDto
        {
            TotalEmployees = total,
            ActiveEmployees = active,
            NewHires = newHires,
            AttritionRate = attrition
        };
        return Task.FromResult(dto);
    }

    public Task<List<GenderDistributionDto>> GetGenderDistributionAsync()
    {
        var total = _store.Employees.Count;
        var list = _store.Employees.GroupBy(e => e.Gender)
            .Select(g => new GenderDistributionDto
            {
                Gender = g.Key,
                Count = g.Count(),
                Percentage = total == 0 ? 0 : Math.Round(g.Count() * 100.0 / total, 0)
            }).ToList();
        return Task.FromResult(list);
    }

    private static DateTime NextOccurrence(DateTime dob, DateTime today)
    {
        var next = new DateTime(today.Year, dob.Month, dob.Day);
        if (next < today) next = next.AddYears(1);
        return next;
    }
}
