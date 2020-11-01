using System;
using System.Diagnostics;
using System.Linq;
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

		private void OnTextChanged(object sender, TextChangedEventArgs? e)
		{
			if (sender is TextBox textBox && TryParseUnit(ref textBox, out var parsedUnit))
			{
				UnHookEvents();
				string whatToExclude = e?.Source is LostFocusUpdate ? "None" : textBox.Name;
				try
				{
					if (KelvinTextBox != null && whatToExclude != KelvinTextBox.Name && parsedUnit is IConversionToKelvin kelvin)
					{
						KelvinTextBox.Text = kelvin.ToKelvin().ToString("0.##########");
					}

					if (CelsiusTextBox != null && whatToExclude != CelsiusTextBox.Name && parsedUnit is IConversionToCelsius celsius)
					{
						CelsiusTextBox.Text = celsius.ToCelsius().ToString("0.##########");
					}

					if (FahrenheitTextBox != null && whatToExclude != FahrenheitTextBox.Name && parsedUnit is IConversionToFahrenheit fahrenheit)
					{
						FahrenheitTextBox.Text = fahrenheit.ToFahrenheit().ToString("0.##########");
					}

					if (RankineTextBox != null && whatToExclude != RankineTextBox.Name && parsedUnit is IConversionToRankine rankine)
					{
						RankineTextBox.Text = rankine.ToRankine().ToString("0.##########");
					}

					if (DelisleTextBox != null && whatToExclude != DelisleTextBox.Name && parsedUnit is IConversionToDelisle delisle)
					{
						DelisleTextBox.Text = delisle.ToDelisle().ToString("0.##########");
					}

					if (NewtonTextBox != null && whatToExclude != NewtonTextBox.Name && parsedUnit is IConversionToNewton newton)
					{
						NewtonTextBox.Text = newton.ToNewton().ToString("0.##########");
					}

					if (RéaumurTextBox != null && whatToExclude != RéaumurTextBox.Name && parsedUnit is IConversionToRéaumur réaumur)
					{
						RéaumurTextBox.Text = réaumur.ToRéaumur().ToString("0.##########");
					}

					if (RømerTextBox != null && whatToExclude != RømerTextBox.Name && parsedUnit is IConversionToRømer rømer)
					{
						RømerTextBox.Text = rømer.ToRømer().ToString("0.##########");
					}
				}
				catch (Exception exception)
				{
					if (KelvinTextBox != null) KelvinTextBox.Text = exception.Message;
					if (CelsiusTextBox != null) CelsiusTextBox.Text = exception.Message;
					if (FahrenheitTextBox != null) FahrenheitTextBox.Text = exception.Message;
					if (RankineTextBox != null) RankineTextBox.Text = exception.Message;
					if (DelisleTextBox != null) DelisleTextBox.Text = exception.Message;
					if (NewtonTextBox != null) NewtonTextBox.Text = exception.Message;
					if (RéaumurTextBox != null) RéaumurTextBox.Text = exception.Message;
					if (RømerTextBox != null) RømerTextBox.Text = exception.Message;
				}
				finally
				{
					HookEvents();
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
				return double.TryParse(CelsiusTextBox.Text, out double valueCel)
					? new Celsius(valueCel)
					: new Celsius(CelsiusTextBox.Text);
			}

			if (textBox.Name == FahrenheitTextBox.Name)
			{
				return double.TryParse(FahrenheitTextBox.Text, out double valueFah)
					? new Fahrenheit(valueFah)
					: new Fahrenheit(FahrenheitTextBox.Text);
			}

			if (textBox.Name == RankineTextBox.Name)
			{
				return double.TryParse(RankineTextBox.Text, out double valueRan)
					? new Rankine(valueRan)
					: new Rankine(RankineTextBox.Text);
			}

			if (textBox.Name == DelisleTextBox.Name)
			{
				return double.TryParse(DelisleTextBox.Text, out double valueDel)
					? new Delisle(valueDel)
					: new Delisle(DelisleTextBox.Text);
			}

			if (textBox.Name == NewtonTextBox.Name)
			{
				return double.TryParse(NewtonTextBox.Text, out double valueNew)
					? new Newton(valueNew)
					: new Newton(NewtonTextBox.Text);
			}

			if (textBox.Name == RéaumurTextBox.Name)
			{
				return double.TryParse(RéaumurTextBox.Text, out double valueRéau)
					? new Réaumur(valueRéau)
					: new Réaumur(RéaumurTextBox.Text);
			}

			return double.TryParse(RømerTextBox.Text, out double valueRøm)
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
			if (sender is TextBox textBox && e != null)
			{
				var textChangedEventArgs = new TextChangedEventArgs(e.RoutedEvent, UndoAction.None) { Source = new LostFocusUpdate() };
				OnTextChanged(sender, textChangedEventArgs);
			}
		}

		private bool TryParseUnit(ref TextBox textBox, out TemperatureUnit? temperatureUnit)
		{
			try
			{
				temperatureUnit = UpdateValueBasedOnTextBlock(ref textBox);
				return true;
			}
			catch
			{
				temperatureUnit = null;
				return false;
			}
		}

		private void UnHookEvents()
		{
			if (KelvinTextBox != null) KelvinTextBox.TextChanged -= OnTextChanged;
			if (CelsiusTextBox != null) CelsiusTextBox.TextChanged -= OnTextChanged;
			if (FahrenheitTextBox != null) FahrenheitTextBox.TextChanged -= OnTextChanged;
			if (RankineTextBox != null) RankineTextBox.TextChanged -= OnTextChanged;
			if (DelisleTextBox != null) DelisleTextBox.TextChanged -= OnTextChanged;
			if (NewtonTextBox != null) NewtonTextBox.TextChanged -= OnTextChanged;
			if (RéaumurTextBox != null) RéaumurTextBox.TextChanged -= OnTextChanged;
			if (RømerTextBox != null) RømerTextBox.TextChanged -= OnTextChanged;
		}

		private void HookEvents()
		{
			if (KelvinTextBox != null) KelvinTextBox.TextChanged += OnTextChanged;
			if (CelsiusTextBox != null) CelsiusTextBox.TextChanged += OnTextChanged;
			if (FahrenheitTextBox != null) FahrenheitTextBox.TextChanged += OnTextChanged;
			if (RankineTextBox != null) RankineTextBox.TextChanged += OnTextChanged;
			if (DelisleTextBox != null) DelisleTextBox.TextChanged += OnTextChanged;
			if (NewtonTextBox != null) NewtonTextBox.TextChanged += OnTextChanged;
			if (RéaumurTextBox != null) RéaumurTextBox.TextChanged += OnTextChanged;
			if (RømerTextBox != null) RømerTextBox.TextChanged += OnTextChanged;
		}
	}

	internal class LostFocusUpdate
	{ }
}
