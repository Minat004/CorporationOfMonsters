using System.Collections.Generic;
using CorpOfMonstersAppV3.Models;

namespace CorpOfMonstersAppV3.Services;

public static class FakeDatabase
{
    public static IEnumerable<Employee> GetWorkers() => new List<Employee>()
    {
        new Employee("Alex", "Bell"),
        new Employee("Masha", "Belska", new Regular(10)),
        new Employee("Masha", "Belska", new Regular()),
        new Employee("Dawid", "Kowalski"),
        new Employee()
        {
            FirstName = "login",
            LastName = "password"
        }
    };

    public static IEnumerable<Contract> GetContracts() => new List<Contract>()
    {
        new Contract()
        {
            Name = "Intern",
            ContractType = new Intern()
        },
        new Contract()
        {
            Name = "Regular",
            ContractType = new Regular()
        }
    };
}