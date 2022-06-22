using System;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CorpOfMonstersAppV3.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;

namespace CorpOfMonstersAppV3.Views;

public partial class AddWindow : ReactiveWindow<AddWindowViewModel>
{
    public AddWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.WhenActivated(disposables =>
        {
            disposables(ViewModel!.AddEmployee!.Subscribe(Close));
            var addContract = this.Find<ComboBox>("AddContract");
            addContract.SelectedIndex = 0;
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