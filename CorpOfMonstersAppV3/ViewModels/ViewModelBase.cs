using System.Collections;
using System.Collections.ObjectModel;
using Avalonia.Collections;
using CorpOfMonstersAppV3.Models;
using ReactiveUI;

namespace CorpOfMonstersAppV3.ViewModels;

public class ViewModelBase : ReactiveObject
{
    
    private ObservableCollection<Employee>? _workers;
    
    public ObservableCollection<Employee>? Workers
    {
        get => _workers;
        set => this.RaiseAndSetIfChanged(ref _workers, value);
    }

    public DataGridCollectionView? WorkersCollectionView { get; set; }

    public static Employee? SelectedWorker { get; set; }

    private int _selectedWorkerIndex;

    public int SelectedWorkerIndex
    {
        get => _selectedWorkerIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedWorkerIndex, value);
    }
}