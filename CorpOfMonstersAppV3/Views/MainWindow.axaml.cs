using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.ReactiveUI;
using CorpOfMonstersAppV3.Models;
using CorpOfMonstersAppV3.ViewModels;
using ReactiveUI;

namespace CorpOfMonstersAppV3.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowAddDialog.RegisterHandler(AddShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowEditDialog.RegisterHandler(EditShowDialogAsync)));
    }

    private async Task AddShowDialogAsync(InteractionContext<AddWindowViewModel, Employee> interaction)
    {
        var dialog = new AddWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<Employee>(this);
        interaction.SetOutput(result);
    }
    
    private async Task EditShowDialogAsync(InteractionContext<EditWindowViewModel, Employee> interaction)
    {
        var dialog = new EditWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<Employee>(this);
        interaction.SetOutput(result);
    }
    
}
