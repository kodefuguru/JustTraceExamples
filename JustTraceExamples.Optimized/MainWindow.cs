namespace JustTraceExamples
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Telerik.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }

        private void ShowTime(object sender, RoutedEventArgs e)
        {
            var timerLeak = new TimerLeak();
            MainGrid.Children.Add(timerLeak);
            Grid.SetRow(timerLeak, 0);
            Grid.SetColumn(timerLeak, 0);
            Grid.SetRowSpan(timerLeak, MainGrid.RowDefinitions.Count);
            timerLeak.Visibility = System.Windows.Visibility.Visible;
            timerLeak.Opacity = 100;
        }
    }
}