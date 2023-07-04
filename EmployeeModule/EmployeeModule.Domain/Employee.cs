namespace EmployeeModule.Domain;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public int EvaluationPoints { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    
    /// <summary>
    /// Employee, AdvancedEmployee or Manager
    /// </summary>
    public string Role { get; set; }
}