using System;
using System.Collections.ObjectModel;
using System.Reactive;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;

namespace CorpOfMonstersAppV3.ViewModels;

public class EditWindowViewModel : ViewModelBase
{
    public EditWindowViewModel(Employee? selectedWorkerDetails)
    {
        this.ValidationRule(x => x.OverHours,
            hours => !string.IsNullOrWhiteSpace(hours) && int.TryParse(hours, out _)
                                                       && int.Parse(hours) >= 0,
            "Only a positive number");
        
        SelectedWorkerDetails = selectedWorkerDetails;
        EditFirstName = SelectedWorkerDetails!.FirstName;
        EditLastName = SelectedWorkerDetails!.LastName;
        OverHours = SelectedWorkerDetails.Contract!.OverHours.ToString();
        
        ContractsCollection = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        EditEmployee = ReactiveCommand.Create(() => 
            new Employee(EditFirstName, EditLastName, new Contract(ComboContractSelected!.Name, 
                int.Parse(OverHours)).ContractType));
    }

    public EditWindowViewModel()
    {
        throw new NotImplementedException();
    }

    public ReactiveCommand<Unit, Employee> EditEmployee { get; }

    public ObservableCollection<Contract>? ContractsCollection { get; set; }


    private Contract? _comboContractSelected;
    public Contract? ComboContractSelected
    {
        get
        {
            _comboContractSelected = _comboContractSelected switch
            {
                null when SelectedWorkerDetails!.Contract is Regular => ContractsCollection![1],
                null when SelectedWorkerDetails!.Contract is Intern => ContractsCollection![0],
                _ => _comboContractSelected
            };
            
            return _comboContractSelected;
        }
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

    private Employee? SelectedWorkerDetails { get; }

    public string? EditFirstName { get; set; }

    public string? EditLastName { get; set; }

    private string? _overHours;
    public string? OverHours
    {
        get => _overHours;
        set
        {
            _overHours = value;
            this.RaisePropertyChanged(nameof(OverHours));
        }
    }

    private bool _overHoursIsEnabled;
    public bool OverHoursIsEnabled
    {
        get => _overHoursIsEnabled = _comboContractSelected!.Name == StringConst.Regular;
        set
        {
            _overHoursIsEnabled = value;
            this.RaisePropertyChanged(nameof(OverHoursIsEnabled));
        }
    }
}