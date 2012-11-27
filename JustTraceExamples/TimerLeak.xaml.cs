namespace JustTraceExamples
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TimerLeak.xaml
    /// </summary>
    public partial class TimerLeak : UserControl
    {
        private TimerLeakViewModel viewModel = new TimerLeakViewModel();

        public TimerLeak()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            ((Grid)this.Parent).Children.Remove(this);
        }
    }
}