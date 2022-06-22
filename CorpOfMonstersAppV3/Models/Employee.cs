namespace CorpOfMonstersAppV3.Models;

public class Employee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IContract? Contract { get; set; }
    public double Salary { get; }
    
    public Employee()
    {
        FirstName = "";
        LastName = "";
        Contract = new Intern();
        Salary = Contract.Salary();
    }
    public Employee(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Contract = new Intern();
        Salary = Contract.Salary();
    }
    public Employee(string? firstName, string? lastName, IContract? arg)
    {
        FirstName = firstName;
        LastName = lastName;
        Contract = arg;
        Salary = Contract!.Salary();
    }
    public void ChangeContract(IContract? arg)
    {
        Contract = arg;
    }

    public Employee ChangeEmployee(Employee employee)
    {
        return employee;
    }
    
    public override string ToString() => $"Name: {FirstName}, Surname: {LastName}, Salary: {Contract!.Salary()}";
}