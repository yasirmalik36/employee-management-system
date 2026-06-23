namespace EmployeeManagementSystem.Models;

public enum AttendanceStatus
{
    Present,
    Absent,
    Late,
    HalfDay,
    OnLeave
}

public class Attendance
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeSpan? CheckIn { get; set; }
    public TimeSpan? CheckOut { get; set; }
    public double WorkingHours { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
}
