using System;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI.Validation.Extensions;

namespace CorpOfMonstersAppV3.ViewModels;

public class AddWindowViewModel : ViewModelBase
{
    public AddWindowViewModel()
    {
        this.ValidationRule(x => x.OverHours,
            hours => !string.IsNullOrWhiteSpace(hours) && int.TryParse(hours, out _) 
                                                       && int.Parse(hours) >= 0,
            "Only a positive number");
        
        Console.WriteLine(OverHours);
        
        ContractsCollection = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        AddEmployee = ReactiveCommand.Create(() => 
            new Employee(AddFirstName, AddLastName, new Contract(ComboContractSelected!.Name, 
                int.Parse(OverHours!)).ContractType));
    }

    public ObservableCollection<Contract> ContractsCollection { get; }

    public ReactiveCommand<Unit, Employee>? AddEmployee { get; }

    private Contract? _comboContractSelected;
    public Contract? ComboContractSelected
    {
        get => _comboContractSelected;
        set
        {
            _comboContractSelected = value;
            OverHoursIsEnabled = _comboContractSelected!.Name == StringConst.Regular;
            if (_comboContractSelected!.Name == StringConst.Intern)
            {
                OverHours = "0";
            }
            this.RaisePropertyChanged(nameof(ComboContractSelected));
        }
    }
    
    public string? AddFirstName { get; set; }

    public string? AddLastName { get; set; }
    
    private bool _overHoursIsEnabled;
    public bool OverHoursIsEnabled
    {
        get => _overHoursIsEnabled;
        set
        {
            _overHoursIsEnabled = value;
            this.RaisePropertyChanged(nameof(OverHoursIsEnabled));
        }
    }

    private string? _overHours = "0";
    public string? OverHours
    {
        get => _overHours;
        set
        {
            _overHours = value;
            this.RaisePropertyChanged(nameof(OverHours));
        }
    }
    
}