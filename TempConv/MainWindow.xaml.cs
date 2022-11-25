using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TempConv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double celsiusTemperature;
        private double fahrenheitTemperature;

        public MainWindow()
        {
            InitializeComponent();
        }

        public double CelsiusTemperature
        {
            get => this.celsiusTemperature;
            set
            {
                this.celsiusTemperature = value;
                this.fahrenheitTemperature = Math.Round(this.celsiusTemperature * (9 / 5.0) + 32);
                OnPropertyChanged(nameof(this.FahrenheitTemperature));
            }
        }

        public double FahrenheitTemperature
        {
            get => this.fahrenheitTemperature;
            set
            {
                this.fahrenheitTemperature = value;
                this.celsiusTemperature = Math.Round((this.fahrenheitTemperature - 32) * (5 / 9.0));
                OnPropertyChanged(nameof(this.CelsiusTemperature));
            }
        }

        private void ShowError()
        {
            var message = "Please, enter a number.";
            MessageBoxButton button = MessageBoxButton.OK;
            var caption = "Validation error.";
            MessageBox.Show(message, caption, button, MessageBoxImage.Error);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
