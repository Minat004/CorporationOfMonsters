using System;
using System.Reactive;
using CorpOfMonstersAppV3.Models;
using ReactiveUI;

namespace CorpOfMonstersAppV3.ViewModels;

public class EditWindowViewModel : ViewModelBase
{
    private string? _firstName;
    private string? _lastName;
    public EditWindowViewModel()
    {
        EditEmployee = ReactiveCommand.Create(() => new Employee(EditFirstName, EditLastName));
        Console.WriteLine(EditEmployee);
    }

    public ReactiveCommand<Unit, Employee> EditEmployee { get; } 

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