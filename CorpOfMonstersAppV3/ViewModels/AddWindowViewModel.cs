using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;

namespace CorpOfMonstersAppV3.ViewModels;

public class AddWindowViewModel : ViewModelBase
{
    public AddWindowViewModel()
    {
        ContractsCollection = new ObservableCollection<Contract>(FakeDatabase.GetContracts());
        AddEmployee = ReactiveCommand.Create(() => 
            new Employee(AddFirstName, AddLastName, new Contract(ComboContractSelected!.Name, OverHours).ContractType));
    }

    public ObservableCollection<Contract> ContractsCollection { get; }

    public ReactiveCommand<Unit, Employee>? AddEmployee { get; }

    private Contract? _comboContractSelected;
    public Contract? ComboContractSelected
    {
        get => _comboContractSelected = ContractsCollection.FirstOrDefault();
        set
        {
            _comboContractSelected = value;
            OverHoursIsEnabled = _comboContractSelected!.Name == StringConst.REGULAR;
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

    public int OverHours { get; set; }
    
}