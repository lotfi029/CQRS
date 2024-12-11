namespace CQRS_V00;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    public decimal Salery { get; set; }
    public decimal Rate { get; set; }
    public bool Status { get; set; }
}
