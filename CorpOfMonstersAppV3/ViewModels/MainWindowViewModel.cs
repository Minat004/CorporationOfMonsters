using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Collections;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using ReactiveUI;

namespace CorpOfMonstersAppV3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? _searchText = string.Empty;

        public MainWindowViewModel()
        {
            Workers = new ObservableCollection<Employee>(FakeDatabase.GetWorkers());
            WorkersCollectionView = new DataGridCollectionView(Workers)
            {
                Filter = FilterGrid
            };
            ShowAddDialog = new Interaction<AddWindowViewModel, Employee>();
            ShowEditDialog = new Interaction<EditWindowViewModel, Employee>();
            AddWindowCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var form = new AddWindowViewModel();
                var result = await ShowAddDialog.Handle(form);
                Workers.Add(result);
            });
            EditWindowCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var form = new EditWindowViewModel();
                var result = await ShowEditDialog.Handle(form);
                Workers[SelectedWorkerIndex] = result;
                Console.WriteLine(SelectedWorkerIndex);
            });
            DeleteCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("delete");
                Workers.RemoveAt(SelectedWorkerIndex);
            });
        }

        private bool FilterGrid(object arg)
        {
            var emp = arg as Employee;
            
            return string.IsNullOrEmpty(SearchText) || emp!.FirstName!.ToLower().Contains(SearchText.ToLower()) 
                                                    || emp.LastName!.ToLower().Contains(SearchText.ToLower());
        }

        // private ObservableCollection<Employee>? _workers;
        // public ObservableCollection<Employee>? Workers
        // {
        //     get => _workers;
        //     set => this.RaiseAndSetIfChanged(ref _workers, value);
        // }
        
        // public Employee? SelectedWorker { get; set; }
        //
        // public int SelectedWorkerIndex { get; set; }

        public ICommand AddWindowCommand { get; }
        
        public ICommand EditWindowCommand { get; }
        
        public ICommand DeleteCommand { get; }
        
        public Interaction<AddWindowViewModel, Employee> ShowAddDialog { get; }
        
        public Interaction<EditWindowViewModel, Employee> ShowEditDialog { get; }

        public string? SearchText
        {
            get => _searchText;
            set
            {
                this.RaiseAndSetIfChanged(ref _searchText, value);
                WorkersCollectionView!.Refresh();
            }
        }
    }
}