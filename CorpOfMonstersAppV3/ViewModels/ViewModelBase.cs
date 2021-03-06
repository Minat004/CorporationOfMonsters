using System.Collections;
using System.Collections.ObjectModel;
using Avalonia.Collections;
using CorpOfMonstersAppV3.Models;
using ReactiveUI;
using ReactiveUI.Validation.Helpers;

namespace CorpOfMonstersAppV3.ViewModels;

public class ViewModelBase : ReactiveValidationObject
{
    
    private ObservableCollection<Employee>? _workers;
    
    public ObservableCollection<Employee>? Workers
    {
        get => _workers;
        set => this.RaiseAndSetIfChanged(ref _workers, value);
    }

    public DataGridCollectionView? WorkersCollectionView { get; set; }

    private Employee? _selectedWorker;
    public Employee? SelectedWorker
    {
        get => _selectedWorker; 
        set => this.RaiseAndSetIfChanged(ref _selectedWorker, value);
    }
    
    private int _selectedWorkerIndex;
    public int SelectedWorkerIndex
    {
        get => _selectedWorkerIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkerIndex, value);
    }
}