using System;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI;
using Contract = CorpOfMonstersAppV3.Models.Contract;

namespace CorpOfMonstersAppV3.ViewModels;

public class EditWindowViewModel : ViewModelBase
{
    private string? _firstName;
    private string? _lastName;
    public EditWindowViewModel(Employee? selectedWorkerDetails)
    {
        SelectedWorkerDetails = selectedWorkerDetails;
        EditFirstName = SelectedWorkerDetails!.FirstName;
        EditLastName = SelectedWorkerDetails!.LastName;
        ComboContractSelected = SelectedWorkerDetails.Contract switch
        {
            Intern => new Contract() { ContractType = new Intern() },
            Regular => new Contract() { ContractType = new Regular() },
            _ => ComboContractSelected
        };
        Contracts = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        EditEmployee = ReactiveCommand.Create(() => 
            new Employee(EditFirstName, EditLastName, ComboContractSelected!.ContractType));
        Console.WriteLine(SelectedWorkerIndex);
        Console.WriteLine(SelectedWorkerDetails!.ToString());
    }

    public ObservableCollection<Contract> Contracts { get; set; }

    public ReactiveCommand<Unit, Employee> EditEmployee { get; }
    
    public Contract? ComboContractSelected { get; set; }

    private Employee? SelectedWorkerDetails { get; }

    public string? EditFirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    public string? EditLastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }
}