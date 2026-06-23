using FluentValidation;
using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Validators;

public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
{
    public EmployeeCreateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Enter a valid email address");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required")
            .MinimumLength(7).WithMessage("Enter a valid phone number");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0).WithMessage("Department is required");

        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("Role is required");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required")
            .LessThan(x => x.JoiningDate).WithMessage("Date of birth must be before joining date")
            .Must(d => d <= DateTime.Today.AddYears(-16)).WithMessage("Employee must be at least 16 years old");

        RuleFor(x => x.JoiningDate)
            .NotEmpty().WithMessage("Joining date is required");
    }
}
