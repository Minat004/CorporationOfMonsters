using System;
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CorpOfMonstersAppV3.ViewModels;
using ReactiveUI;

namespace CorpOfMonstersAppV3.Views;

public partial class EditWindow : ReactiveWindow<EditWindowViewModel>
{
    public EditWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.WhenActivated(d =>
        {
            d(ViewModel!.EditEmployee.Subscribe(Close));
            // var editContract = this.Find<ComboBox>("EditContract");
            // editContract.SelectedIndex = 0;
        });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}