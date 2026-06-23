using FluentValidation;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Validators;

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Role title is required").MaximumLength(80);
        RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Department is required");
    }
}
