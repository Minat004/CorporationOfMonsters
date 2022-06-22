using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI.Fody.Helpers;

namespace CorpOfMonstersAppV3.ViewModels;

public class AddWindowViewModel : ViewModelBase
{
    public AddWindowViewModel()
    {
        Contracts = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        AddEmployee = ReactiveCommand.Create(() => new Employee(AddFirstName, AddLastName, ComboContractSelected!.ContractType));
    }

    public ObservableCollection<Contract> Contracts { get; }

    public ReactiveCommand<Unit, Employee>? AddEmployee { get; }
    
    public Contract? ComboContractSelected { get; set; }
    
    public string? AddFirstName { get; set; }

    public string? AddLastName { get; set; }
}