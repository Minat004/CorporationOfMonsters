using System;
using System.Collections.ObjectModel;
using System.Reactive;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI;

namespace CorpOfMonstersAppV3.ViewModels;

public class EditWindowViewModel : ViewModelBase
{
    public EditWindowViewModel(Employee? selectedWorkerDetails)
    {
        SelectedWorkerDetails = selectedWorkerDetails;
        EditFirstName = SelectedWorkerDetails!.FirstName;
        EditLastName = SelectedWorkerDetails!.LastName;
        OverHours = SelectedWorkerDetails.Contract!.OverHours;
        Console.WriteLine($"over hours {OverHours}");
        ContractsCollection = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        EditEmployee = ReactiveCommand.Create(() => 
            new Employee(EditFirstName, EditLastName, new Contract(ComboContractSelected!.Name, OverHours).ContractType));
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
            OverHoursIsEnabled = _comboContractSelected!.Name == StringConst.REGULAR;
            this.RaisePropertyChanged(nameof(ComboContractSelected));
        }
    }

    private Employee? SelectedWorkerDetails { get; }

    public string? EditFirstName { get; set; }

    public string? EditLastName { get; set; }

    public int OverHours { get; set; }

    private bool _overHoursIsEnabled;
    public bool OverHoursIsEnabled
    {
        get => _overHoursIsEnabled = _comboContractSelected!.Name == StringConst.REGULAR;
        set
        {
            _overHoursIsEnabled = value;
            this.RaisePropertyChanged(nameof(OverHoursIsEnabled));
        }
    }
}