namespace CQRS_V00.Contract;

public record EmployeeResponse (
    string Id,
    string Name,
    string Salary,
    DateOnly BirthDay,
    decimal Rate
);
