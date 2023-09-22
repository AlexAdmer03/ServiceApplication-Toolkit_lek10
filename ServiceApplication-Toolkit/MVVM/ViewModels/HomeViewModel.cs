using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ServiceApplication_Toolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication_Toolkit.MVVM.ViewModels
{

    public partial class HomeViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DateTimeService _dateTimeService;
        private readonly WeatherService _weatherService;

        public HomeViewModel(IServiceProvider serviceProvider, DateTimeService dateTimeService, WeatherService weatherService)
        {
            _serviceProvider = serviceProvider;
            _dateTimeService = dateTimeService;
            _weatherService = weatherService;
            UpdateDateTime();

        }

        [ObservableProperty]
        private string? _title = "Home";

        [ObservableProperty]
        private string? _currentTime = "--:--";

        [ObservableProperty]
        private string? _currentDate;

        [ObservableProperty]
        private string? _currentWeatherCondition = "\ue137";

        [ObservableProperty]
        private string? _currentTemperature;

        [ObservableProperty]
        private string? _currentTemperatureUnit = "C";

        [RelayCommand]
        private void NavigateToSettings()
        {

        }

        private void UpdateDateTime()
        {
            _dateTimeService.TimeUpdated += () =>
            {
                CurrentDate = _dateTimeService.CurrentDate;
                CurrentTime = _dateTimeService.CurrentTime;
            };
        } 
        private void UpdateWeather()
        {
            _weatherService.WeatherUpdated += () =>
            {
                CurrentWeatherCondition = _weatherService.CurrentWeatherCondition;
                CurrentTemperature = _weatherService.CurrentTemperature;
            };
        }
    }

}


