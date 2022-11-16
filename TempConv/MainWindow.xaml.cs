﻿using System;
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
        }

        private void Fahrenheit_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            double tempF = 0;
            if (double.TryParse(Fahrenheit.Text, out tempF))
            {
                var tempC = Math.Round((tempF - 32) * (5 / 9.0));
                Celsius.Text = tempC.ToString();
            }
        }
    }
}