namespace CQRS_V00.Contract;

public record EmployeeRequest(
    string Name, 
    decimal Salary,
    decimal Rate
);
