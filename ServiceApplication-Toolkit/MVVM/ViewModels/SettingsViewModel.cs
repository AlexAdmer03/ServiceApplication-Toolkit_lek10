using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication_Toolkit.MVVM.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _title = "Settings";

        [ObservableProperty]
        private ObservableObject? _currentContentViewModel;

        [RelayCommand]
        private void NavigateHome()
        {

        }

        [RelayCommand]
        private void ShowAddDevice()
        {

        }

        [RelayCommand]
        private void ShowDeviceList()
        {

        }

        [RelayCommand]
        private void ShowConfiguration()
        {

        }

        [RelayCommand]
        private void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
