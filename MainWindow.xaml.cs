using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Terra_Telemetry_App
{
    public partial class MainWindow : Window
    {
        public class TelemetryData
        {
            public double EngineChamberTemperature { get; set; }
            public double EngineChamberPressure { get; set; }
            public double GOXFuelLevel { get; set; }
            public double EthanolFuelLevel { get; set; }
            public double GOXFuelTankPressure { get; set; }
            public double EthanolFuelTankPressure { get; set; }
        }

        private TelemetryData _telemetryData = new TelemetryData();
        public MainWindow()
        {
            InitializeComponent();
            UpdateTelemetryDisplay();
        }
        private void UpdateTelemetryDisplay()
        {
            TempTextBlock.Text = _telemetryData.EngineChamberTemperature.ToString();
            PressureTextBlock.Text = _telemetryData.EngineChamberPressure.ToString();
            GOXLevelTextBlock.Text = _telemetryData.GOXFuelLevel.ToString();
            EthanolLevelTextBlock.Text = _telemetryData.EthanolFuelLevel.ToString();
            GOXPressureTextBlock.Text = _telemetryData.GOXFuelTankPressure.ToString();
            EthanolPressureTextBlock.Text = _telemetryData.EthanolFuelTankPressure.ToString();
        }
        private void CheckforUpdate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Check for update and display message box with result
            MessageBox.Show("No update available.", "Check for Update");
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // Get the current mouse position
                Point mousePos = e.GetPosition(this);

                // Set the cursor to the drag cursor
                this.Cursor = Cursors.SizeAll;

                // Begin dragging the window
                this.DragMove();

                // Restore the cursor after dragging is complete
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
