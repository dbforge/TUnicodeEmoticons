using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        private static SettingsViewModel _instance;
        public static SettingsViewModel Instance => _instance ?? (_instance = new SettingsViewModel());
        
        private SettingsViewModel()
        {
            _firstKeyCollection = new ObservableCollection<string> { "Control", "Alt" };
            _secondKeyCollection = new ObservableCollection<string> { "Shift", "Win" };
            _thirdKeyCollection = new ObservableCollection<Key>(Enum.GetValues(typeof(Key)).Cast<Key>());
        }
        
        public HotKeyData HotKeyData => Session.Settings.HotKeyData;

        private ObservableCollection<string> _firstKeyCollection;
        public ObservableCollection<string> FirstKeyCollection
        {
            get { return _firstKeyCollection; }
            set
            {
                _firstKeyCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _secondKeyCollection;
        public ObservableCollection<string> SecondKeyCollection
        {
            get { return _secondKeyCollection; }
            set
            {
                _secondKeyCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Key> _thirdKeyCollection;
        public ObservableCollection<Key> ThirdKeyCollection
        {
            get { return _thirdKeyCollection; }
            set
            {
                _thirdKeyCollection = value;
                OnPropertyChanged();
            }
        }

        public bool AutoClosePopup
        {
            get { return Session.Settings.AutoCloseWindow; }
            set
            {
                Session.Settings.AutoCloseWindow = value;
                OnPropertyChanged(nameof(AutoClosePopup));
            }
        }

        public HorizontalWindowPosition PopupHorizontalPosition
        {
            get { return Session.Settings.PopupHorizontalPosition; }
            set
            {
                Session.Settings.PopupHorizontalPosition = value;
                OnPropertyChanged(nameof(PopupHorizontalPosition));
            }
        }

        public VerticalWindowPosition PopupVerticalPosition
        {
            get { return Session.Settings.PopupVerticalPosition; }
            set
            {
                Session.Settings.PopupVerticalPosition = value;
                OnPropertyChanged(nameof(PopupVerticalPosition));
            }
        }
    }
}