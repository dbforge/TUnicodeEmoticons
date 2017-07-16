using System;
using System.Windows;

// ReSharper disable InconsistentNaming

namespace TUnicodeEmoticons
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            try
            {
                Session.InitializeData();
            }
            catch
            {
                if (MessageBox.Show("The program specific data could not be initialized.", "Error while loading the data.",
                    MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    throw;
            }

            try
            {
                Session.InitializeNotifyIcon();
            }
            catch
            {
                if (MessageBox.Show("The notify icon could not be initialized.", "Error while initializing the notify icon.",
                        MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    throw;
            }

            try
            {
                Session.InitializeHotKey();
            }
            catch
            {
                if (MessageBox.Show("The hotkey could not be registered correctly.", "Error while registering the hotkey.",
                        MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                    throw;
            }

            application.Run();
        }
    }
}