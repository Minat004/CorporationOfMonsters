using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using CorpOfMonstersAppV3.Models;
using ReactiveUI.Fody.Helpers;

namespace CorpOfMonstersAppV3.ViewModels;

public class AddWindowViewModel : ViewModelBase
{
    public AddWindowViewModel()
    {
        Contracts = new ObservableCollection<string>
        {
            "Intern",
            "Regular"
        };
        AddEmployee = ComboContractSelected switch
        {
            "Intern" => ReactiveCommand.Create(() => new Employee(AddFirstName, AddLastName)),
            "Regular" => ReactiveCommand.Create(() => new Employee(AddFirstName, AddLastName, new Regular())),
            _ => ReactiveCommand.Create(() => new Employee())
        };
        Console.WriteLine(ComboContractSelected);
    }
    
    public ObservableCollection<string> Contracts { get; }

    public ReactiveCommand<Unit, Employee>? AddEmployee { get; } 
    
    public string? ComboContractSelected { get; set; }
    
    public string? AddFirstName { get; set; }

    public string? AddLastName { get; set; }
}