using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data;

/// <summary>
/// Singleton in-memory data store seeded with fake/mock data so the app is fully
/// demoable without a real SQL Server connection. Swap service implementations to
/// use AppDbContext + SQL Server when a real backing store is available.
/// </summary>
public class InMemoryDataStore
{
    public List<Department> Departments { get; } = new();
    public List<Role> Roles { get; } = new();
    public List<Employee> Employees { get; } = new();
    public List<Attendance> Attendances { get; } = new();
    public List<LeaveRequest> LeaveRequests { get; } = new();
    public List<PerformanceReview> PerformanceReviews { get; } = new();

    private int _nextEmployeeId;
    private int _nextAttendanceId = 1;
    private int _nextLeaveId = 1;
    private int _nextPerformanceId = 1;

    public InMemoryDataStore()
    {
        SeedDepartmentsAndRoles();
        SeedEmployees();
        SeedAttendance();
        SeedLeaveRequests();
        SeedPerformanceReviews();
    }

    private void SeedDepartmentsAndRoles()
    {
        Departments.AddRange(new[]
        {
            new Department { Id = 1, Name = "IT", Description = "Information Technology", ColorHex = "#594AE2" },
            new Department { Id = 2, Name = "HR", Description = "Human Resources", ColorHex = "#FF6B8B" },
            new Department { Id = 3, Name = "Finance", Description = "Finance & Accounting", ColorHex = "#FFB547" },
            new Department { Id = 4, Name = "Sales", Description = "Sales", ColorHex = "#29C7AC" },
            new Department { Id = 5, Name = "Marketing", Description = "Marketing", ColorHex = "#4FB7FF" },
        });

        Roles.AddRange(new[]
        {
            new Role { Id = 1, Title = "Software Developer", DepartmentId = 1 },
            new Role { Id = 2, Title = "UI/UX Designer", DepartmentId = 1 },
            new Role { Id = 3, Title = "DevOps Engineer", DepartmentId = 1 },
            new Role { Id = 4, Title = "HR Manager", DepartmentId = 2 },
            new Role { Id = 5, Title = "Recruiter", DepartmentId = 2 },
            new Role { Id = 6, Title = "Accountant", DepartmentId = 3 },
            new Role { Id = 7, Title = "Financial Analyst", DepartmentId = 3 },
            new Role { Id = 8, Title = "Sales Manager", DepartmentId = 4 },
            new Role { Id = 9, Title = "Marketing Specialist", DepartmentId = 5 },
        });
    }

    private void SeedEmployees()
    {
        var seed = new List<(string First, string Last, int Dept, int Role, string Email, string Status, string Gender, int AgeYears, int JoinMonthsAgo)>
        {
            ("John", "Doe", 1, 1, "john.doe@company.com", "Active", "Male", 30, 18),
            ("Jane", "Smith", 2, 4, "jane.smith@company.com", "Active", "Female", 34, 22),
            ("Michael", "Brown", 1, 2, "michael.brown@company.com", "Active", "Male", 27, 14),
            ("Emily", "Johnson", 3, 6, "emily.johnson@company.com", "Active", "Female", 29, 30),
            ("David", "Wilson", 4, 8, "david.wilson@company.com", "OnLeave", "Male", 38, 40),
            ("Sarah", "Davis", 5, 9, "sarah.davis@company.com", "Active", "Female", 26, 9),
            ("Robert", "Taylor", 1, 3, "robert.taylor@company.com", "Active", "Male", 31, 11),
            ("Lisa", "Anderson", 2, 5, "lisa.anderson@company.com", "Active", "Female", 28, 6),
            ("James", "Martinez", 1, 1, "james.martinez@company.com", "Active", "Male", 33, 24),
            ("Patricia", "Garcia", 3, 7, "patricia.garcia@company.com", "Active", "Female", 36, 50),
            ("Daniel", "Lee", 4, 8, "daniel.lee@company.com", "Active", "Male", 29, 5),
            ("Susan", "White", 5, 9, "susan.white@company.com", "Inactive", "Female", 41, 70),
            ("Christopher", "Harris", 1, 2, "christopher.harris@company.com", "Active", "Male", 25, 3),
            ("Karen", "Clark", 2, 4, "karen.clark@company.com", "Active", "Female", 39, 60),
            ("Matthew", "Lewis", 1, 3, "matthew.lewis@company.com", "Active", "Male", 32, 16),
            ("Nancy", "Walker", 3, 6, "nancy.walker@company.com", "OnLeave", "Female", 27, 8),
            ("Joseph", "Hall", 4, 8, "joseph.hall@company.com", "Active", "Male", 35, 28),
            ("Margaret", "Young", 5, 9, "margaret.young@company.com", "Active", "Female", 24, 2),
            ("Charles", "King", 1, 1, "charles.king@company.com", "Active", "Male", 30, 20),
            ("Betty", "Wright", 2, 5, "betty.wright@company.com", "Active", "Female", 26, 4),
        };

        _nextEmployeeId = 1;
        var rnd = new Random(42);
        var skillPool = new[] { "C#", ".NET", "Blazor", "SQL Server", "JavaScript", "HTML", "CSS", "Azure", "React", "Leadership", "Excel", "Communication" };

        foreach (var s in seed)
        {
            var id = _nextEmployeeId++;
            var dept = Departments.First(d => d.Id == s.Dept);
            var role = Roles.First(r => r.Id == s.Role);
            var status = Enum.Parse<EmployeeStatus>(s.Status);
            var skills = skillPool.OrderBy(_ => rnd.Next()).Take(rnd.Next(3, 6)).ToList();

            Employees.Add(new Employee
            {
                Id = id,
                EmployeeCode = $"EMP{id:D3}",
                FirstName = s.First,
                LastName = s.Last,
                Email = s.Email,
                Phone = $"+1 555 {rnd.Next(100, 999)} {rnd.Next(1000, 9999)}",
                DepartmentId = dept.Id,
                DepartmentName = dept.Name,
                RoleId = role.Id,
                RoleTitle = role.Title,
                EmploymentType = EmploymentType.FullTime,
                Status = status,
                DateOfBirth = DateTime.Today.AddYears(-s.AgeYears).AddDays(rnd.Next(-20, 20)),
                JoiningDate = DateTime.Today.AddMonths(-s.JoinMonthsAgo),
                ProfilePictureUrl = $"https://i.pravatar.cc/150?img={(id % 70) + 1}",
                Location = "New York, USA",
                About = $"Experienced {role.Title} with a strong background in {dept.Name} operations.",
                Skills = skills,
                PerformanceRating = Math.Round(3.5 + rnd.NextDouble() * 1.5, 1),
                AnnualLeaveBalance = rnd.Next(4, 13),
                SickLeaveBalance = rnd.Next(1, 7),
                CasualLeaveBalance = rnd.Next(0, 3),
                Gender = s.Gender
            });
        }

        // assign reporting managers (first employee per department acts as manager for the rest)
        foreach (var dept in Departments)
        {
            var deptEmployees = Employees.Where(e => e.DepartmentId == dept.Id).ToList();
            if (deptEmployees.Count < 2) continue;
            var manager = deptEmployees[0];
            foreach (var emp in deptEmployees.Skip(1))
            {
                emp.ReportingManagerId = manager.Id;
                emp.ReportingManagerName = manager.FullName;
            }
        }

        foreach (var dept in Departments)
            dept.EmployeeCount = Employees.Count(e => e.DepartmentId == dept.Id);
        foreach (var role in Roles)
            role.EmployeeCount = Employees.Count(e => e.RoleId == role.Id);
    }

    private void SeedAttendance()
    {
        var rnd = new Random(7);
        foreach (var emp in Employees)
        {
            for (int d = 0; d < 14; d++)
            {
                var date = DateTime.Today.AddDays(-d);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) continue;

                var roll = rnd.Next(0, 100);
                AttendanceStatus status;
                TimeSpan? checkIn = null, checkOut = null;
                double hours = 0;

                if (emp.Status == EmployeeStatus.OnLeave && d < 3)
                {
                    status = AttendanceStatus.OnLeave;
                }
                else if (roll < 80)
                {
                    status = AttendanceStatus.Present;
                    checkIn = new TimeSpan(9, rnd.Next(0, 30), 0);
                    checkOut = new TimeSpan(17, rnd.Next(0, 45), 0);
                    hours = Math.Round((checkOut.Value - checkIn.Value).TotalHours, 1);
                }
                else if (roll < 90)
                {
                    status = AttendanceStatus.Late;
                    checkIn = new TimeSpan(9, rnd.Next(31, 59), 0);
                    checkOut = new TimeSpan(17, rnd.Next(0, 45), 0);
                    hours = Math.Round((checkOut.Value - checkIn.Value).TotalHours, 1);
                }
                else if (roll < 95)
                {
                    status = AttendanceStatus.HalfDay;
                    checkIn = new TimeSpan(9, 0, 0);
                    checkOut = new TimeSpan(13, 0, 0);
                    hours = 4;
                }
                else
                {
                    status = AttendanceStatus.Absent;
                }

                Attendances.Add(new Attendance
                {
                    Id = _nextAttendanceId++,
                    EmployeeId = emp.Id,
                    EmployeeName = emp.FullName,
                    Date = date,
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    WorkingHours = hours,
                    Status = status
                });
            }
        }
    }

    private void SeedLeaveRequests()
    {
        var rnd = new Random(11);
        var types = Enum.GetValues<LeaveType>();
        var reasons = new[] { "Family vacation", "Medical appointment", "Personal matters", "Festival", "Rest & recovery" };

        foreach (var emp in Employees.Take(12))
        {
            var start = DateTime.Today.AddDays(rnd.Next(-20, 20));
            var days = rnd.Next(1, 5);
            var status = (LeaveStatus)rnd.Next(0, 3);

            LeaveRequests.Add(new LeaveRequest
            {
                Id = _nextLeaveId++,
                EmployeeId = emp.Id,
                EmployeeName = emp.FullName,
                LeaveType = types[rnd.Next(types.Length)],
                StartDate = start,
                EndDate = start.AddDays(days - 1),
                Reason = reasons[rnd.Next(reasons.Length)],
                Status = status
            });
        }
    }

    private void SeedPerformanceReviews()
    {
        var rnd = new Random(13);
        var goalTitles = new[] { "Improve code quality", "Lead sprint planning", "Complete certification", "Mentor junior staff", "Reduce ticket backlog", "Client satisfaction score" };

        foreach (var emp in Employees)
        {
            var goals = goalTitles.OrderBy(_ => rnd.Next()).Take(3)
                .Select((g, idx) => new PerformanceGoal { Id = idx + 1, Title = g, ProgressPercent = rnd.Next(20, 100) })
                .ToList();

            PerformanceReviews.Add(new PerformanceReview
            {
                Id = _nextPerformanceId++,
                EmployeeId = emp.Id,
                EmployeeName = emp.FullName,
                DepartmentName = emp.DepartmentName,
                Rating = emp.PerformanceRating,
                Month = DateTime.Today.ToString("MMMM yyyy"),
                Goals = goals
            });
        }
    }

    public int GetNextEmployeeId() => Employees.Count == 0 ? 1 : Employees.Max(e => e.Id) + 1;
}
