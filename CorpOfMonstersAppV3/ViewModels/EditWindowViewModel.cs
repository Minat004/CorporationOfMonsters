using System;
using System.Collections.ObjectModel;
using System.Reactive;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI;
using Contract = CorpOfMonstersAppV3.Models.Contract;

namespace CorpOfMonstersAppV3.ViewModels;

public class EditWindowViewModel : ViewModelBase
{
    private Contract? _comboContractSelected;
    private bool _overHoursIsEnabled;

    public EditWindowViewModel(Employee? selectedWorkerDetails)
    {
        SelectedWorkerDetails = selectedWorkerDetails;
        EditFirstName = SelectedWorkerDetails!.FirstName;
        EditLastName = SelectedWorkerDetails!.LastName;
        ComboContractSelected = new Contract(StringConst.REGULAR, 1);
        ContractsCollection = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        EditEmployee = ReactiveCommand.Create(() => 
            new Employee(EditFirstName, EditLastName, new Contract(ComboContractSelected!.Name, OverHours).ContractType));
    }

    public EditWindowViewModel()
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<Contract> ContractsCollection { get; set; }

    public ReactiveCommand<Unit, Employee> EditEmployee { get; }

    public Contract? ComboContractSelected
    {
        get => _comboContractSelected;
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

    public bool OverHoursIsEnabled
    {
        get => _overHoursIsEnabled;
        set
        {
            _overHoursIsEnabled = value;
            this.RaisePropertyChanged(nameof(OverHoursIsEnabled));
        }
    }
}