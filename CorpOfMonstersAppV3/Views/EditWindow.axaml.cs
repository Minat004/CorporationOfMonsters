using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
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
            var editContract = this.Find<ComboBox>("EditContract");
            var editFirstName = this.Find<TextBox>("EditFirstName");
            var editLastName = this.Find<TextBox>("EditLastName");
            editContract.SelectedIndex = 0;
            // editFirstName.Text = "1";
            // editLastName.Text = "2";
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