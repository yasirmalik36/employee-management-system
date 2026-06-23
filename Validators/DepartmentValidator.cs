using FluentValidation;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Validators;

public class DepartmentValidator : AbstractValidator<Department>
{
    public DepartmentValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Department name is required").MaximumLength(50);
    }
}
