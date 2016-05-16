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
            
            Session.InitializeData();
            Session.InitializeNotifyIcon();
            Session.InitializeHotKey();

            application.Run();
        }
    }
}