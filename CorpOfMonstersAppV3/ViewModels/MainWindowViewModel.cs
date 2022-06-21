using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.Services;
using DynamicData;
using ReactiveUI;

namespace CorpOfMonstersAppV3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Workers = new ObservableCollection<Employee>(FakeDatabase.GetWorkers());
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
                Console.WriteLine(SelectedWorkerIndex);
                Console.WriteLine(SelectedWorker?.Contract);
                Workers[SelectedWorkerIndex] = result;
            });
        }

        private ObservableCollection<Employee>? _workers;
        public ObservableCollection<Employee>? Workers
        {
            get => _workers;
            set => this.RaiseAndSetIfChanged(ref _workers, value);
        }
        
        public Employee? SelectedWorker { get; set; }
        public int SelectedWorkerIndex { get; set; }

        public ICommand AddWindowCommand { get; }
        
        public ICommand EditWindowCommand { get; }
        
        public Interaction<AddWindowViewModel, Employee> ShowAddDialog { get; }
        
        public Interaction<EditWindowViewModel, Employee> ShowEditDialog { get; }
    }
}