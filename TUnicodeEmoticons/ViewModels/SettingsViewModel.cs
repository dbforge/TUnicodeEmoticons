using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        public SettingsViewModel()
        {
            _firstKeyCollection = new ObservableCollection<string> { "Control", "Alt" };
            _secondKeyCollection = new ObservableCollection<string> { "Shift", "Win" };
            _thirdKeyCollection = new ObservableCollection<string>(Enum.GetValues(typeof(Key)).Cast<Key>()
                .Select(key => key.ToString()).ToList());
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

        private ObservableCollection<string> _thirdKeyCollection;
        public ObservableCollection<string> ThirdKeyCollection
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
                OnPropertyChanged();
            }
        }

        public HorizontalWindowPosition PopupHorizontalPosition
        {
            get { return Session.Settings.PopupHorizontalPosition; }
            set
            {
                Session.Settings.PopupHorizontalPosition = value;
                OnPropertyChanged();
            }
        }

        public VerticalWindowPosition PopupVerticalPosition
        {
            get { return Session.Settings.PopupVerticalPosition; }
            set
            {
                Session.Settings.PopupVerticalPosition = value;
                OnPropertyChanged();
            }
        }
    }
}