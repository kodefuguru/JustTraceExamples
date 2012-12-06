namespace JustTraceExamples
{
    using System;
    using System.Linq;
    using System.Windows;
    using Telerik.Windows.Controls;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Expression_DarkTheme();
        }
    }
}