using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OnTextChanged(KelvinTextBox, null);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                try
                {
                    if (KelvinTextBox != null && textBox.Name != KelvinTextBox?.Name)
                    {
                        KelvinTextBox.TextChanged -= OnTextChanged;
                        KelvinTextBox.Text = ((IConversionToKelvin)UpdateValueBasedOnTextBlock(ref textBox)).ToKelvin()
                            .ToString("0.##########");
                        KelvinTextBox.TextChanged += OnTextChanged;
                    }

                    if (CelsiusTextBox != null && textBox.Name != CelsiusTextBox?.Name)
                    {
                        CelsiusTextBox.TextChanged -= OnTextChanged;
                        CelsiusTextBox.Text = ((IConversionToCelsius)UpdateValueBasedOnTextBlock(ref textBox))
                            .ToCelsius().ToString("0.##########");
                        CelsiusTextBox.TextChanged += OnTextChanged;
                    }

                    if (FahrenheitTextBox != null && textBox.Name != FahrenheitTextBox?.Name)
                    {
                        FahrenheitTextBox.TextChanged -= OnTextChanged;
                        FahrenheitTextBox.Text = ((IConversionToFahrenheit)UpdateValueBasedOnTextBlock(ref textBox))
                            .ToFahrenheit().ToString("0.##########");
                        FahrenheitTextBox.TextChanged += OnTextChanged;
                    }

                    if (RankineTextBox != null && textBox.Name != RankineTextBox?.Name)
                    {
                        RankineTextBox.TextChanged -= OnTextChanged;
                        RankineTextBox.Text = ((IConversionToRankine)UpdateValueBasedOnTextBlock(ref textBox))
                            .ToRankine().ToString("0.##########");
                        RankineTextBox.TextChanged += OnTextChanged;
                    }

                    if (DelisleTextBox != null && textBox.Name != DelisleTextBox?.Name)
                    {
                        DelisleTextBox.TextChanged -= OnTextChanged;
                        DelisleTextBox.Text = ((IConversionToDelisle)UpdateValueBasedOnTextBlock(ref textBox))
                            .ToDelisle().ToString("0.##########");
                        DelisleTextBox.TextChanged += OnTextChanged;
                    }

                    if (NewtonTextBox != null && textBox.Name != NewtonTextBox?.Name)
                    {
                        NewtonTextBox.TextChanged -= OnTextChanged;
                        NewtonTextBox.Text = ((IConversionToNewton)UpdateValueBasedOnTextBlock(ref textBox)).ToNewton()
                            .ToString("0.##########");
                        NewtonTextBox.TextChanged += OnTextChanged;
                    }

                    if (RéaumurTextBox != null && textBox.Name != RéaumurTextBox?.Name)
                    {
                        RéaumurTextBox.TextChanged -= OnTextChanged;
                        RéaumurTextBox.Text = ((IConversionToRéaumur)UpdateValueBasedOnTextBlock(ref textBox))
                            .ToRéaumur().ToString("0.##########");
                        RéaumurTextBox.TextChanged += OnTextChanged;
                    }

                    if (RømerTextBox != null && textBox.Name != RømerTextBox?.Name)
                    {
                        RømerTextBox.TextChanged -= OnTextChanged;
                        RømerTextBox.Text = ((IConversionToRømer)UpdateValueBasedOnTextBlock(ref textBox)).ToRømer()
                            .ToString("0.##########");
                        RømerTextBox.TextChanged += OnTextChanged;
                    }
                }
                catch (Exception exception)
                {
                    KelvinTextBox.Text = exception.Message;
                    CelsiusTextBox.Text = exception.Message;
                    FahrenheitTextBox.Text = exception.Message;
                    RankineTextBox.Text = exception.Message;
                    DelisleTextBox.Text = exception.Message;
                    NewtonTextBox.Text = exception.Message;
                    RéaumurTextBox.Text = exception.Message;
                    RømerTextBox.Text = exception.Message;
                }
            }
        }

        private TemperatureUnit UpdateValueBasedOnTextBlock(ref TextBox textBox)
        {
            if (textBox.Name == KelvinTextBox.Name)
            {
                return new Kelvin(KelvinTextBox.Text);
            }

            if (textBox.Name == CelsiusTextBox.Name)
            {
                return Double.TryParse(CelsiusTextBox.Text, out var valueCel)
                    ? new Celsius(valueCel)
                    : new Celsius(CelsiusTextBox.Text + " °C");
            }

            if (textBox.Name == FahrenheitTextBox.Name)
            {
                return Double.TryParse(FahrenheitTextBox.Text, out var valueFah)
                    ? new Fahrenheit(valueFah)
                    : new Fahrenheit(FahrenheitTextBox.Text);
            }

            if (textBox.Name == RankineTextBox.Name)
            {
                return Double.TryParse(RankineTextBox.Text, out var valueRan)
                    ? new Rankine(valueRan)
                    : new Rankine(RankineTextBox.Text);
            }

            if (textBox.Name == DelisleTextBox.Name)
            {
                return Double.TryParse(DelisleTextBox.Text, out var valueDel)
                    ? new Delisle(valueDel)
                    : new Delisle(DelisleTextBox.Text);
            }

            if (textBox.Name == NewtonTextBox.Name)
            {
                return Double.TryParse(NewtonTextBox.Text, out var valueNew)
                    ? new Newton(valueNew)
                    : new Newton(NewtonTextBox.Text);
            }

            if (textBox.Name == RéaumurTextBox.Name)
            {
                return Double.TryParse(RéaumurTextBox.Text, out var valueRéau)
                    ? new Réaumur(valueRéau)
                    : new Réaumur(RéaumurTextBox.Text);
            }

            return Double.TryParse(RømerTextBox.Text, out var valueRøm)
                ? new Rømer(valueRøm)
                : new Rømer(RéaumurTextBox.Text);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = UpdateValueBasedOnTextBlock(ref textBox).ToString("0.##########");
            }
        }
    }
}
