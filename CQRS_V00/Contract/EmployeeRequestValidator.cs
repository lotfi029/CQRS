using FluentValidation;

namespace CQRS_V00.Contract;

public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
{
    public EmployeeRequestValidator()
    {
        RuleFor(e => e.Salary)
            .NotEmpty();

        RuleFor(e => e.Name)
            .NotEmpty();

        RuleFor(e => e.Rate)
            .NotEmpty();
  
    }
}
