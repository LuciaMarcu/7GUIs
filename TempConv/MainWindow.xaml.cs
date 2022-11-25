using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Celsius_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           if (double.TryParse(Celsius.Text, out double tempC))
           {
                var tempF = Math.Round(tempC * (9 / 5.0) + 32);
                Fahrenheit.Text = tempF.ToString();
           }
           else
           {
               if (Celsius.Text != string.Empty)
               {
                   ShowError();
               }

               Fahrenheit.Text = String.Empty;
           }
        }

        private void Fahrenheit_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (double.TryParse(Fahrenheit.Text, out double tempF))
            {
                var tempC = Math.Round((tempF - 32) * (5 / 9.0));
                Celsius.Text = tempC.ToString();
            }
            else
            {
                if (Fahrenheit.Text != String.Empty)
                {
                    ShowError();
                }

                Celsius.Text = String.Empty;
            }
        }

        private void ShowError()
        {
            var message = "Please, enter a number.";
            MessageBoxButton button = MessageBoxButton.OK;
            var caption = "Validation error.";
            MessageBox.Show(message, caption, button, MessageBoxImage.Error);
        }
    }
}
