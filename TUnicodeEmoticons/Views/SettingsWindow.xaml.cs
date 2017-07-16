using System.Windows;
using TUnicodeEmoticons.ViewModels;

namespace TUnicodeEmoticons.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        private SettingsWindow()
        {
            InitializeComponent();
            DataContext = SettingsViewModel.Instance;
        }

        private static SettingsWindow _instance;
        public static SettingsWindow Instance
        {
            get
            {
                if (_instance == null || PresentationSource.FromVisual(_instance) == null)
                    _instance = new SettingsWindow();
                return _instance;
            }
        }
    }
}