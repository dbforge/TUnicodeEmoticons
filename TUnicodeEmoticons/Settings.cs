using System;
using System.Linq;
using System.Windows.Input;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons
{
    public class Settings : PropertyChangedBase
    {
        private bool _autoCloseWindow;
        private readonly HotKeyData _hotKeyData;
        private HorizontalWindowPosition _popupHorizontalAlignment;
        private VerticalWindowPosition _popupVerticalAlignment;

        public Settings(bool autoCloseWindow, HotKeyData hotKeyData, HorizontalWindowPosition popupHorizontalAlignment, VerticalWindowPosition popupVerticalAlignment)
        {
            AutoCloseWindow = autoCloseWindow;
            _hotKeyData = hotKeyData;
            PopupHorizontalPosition = popupHorizontalAlignment;
            PopupVerticalPosition = popupVerticalAlignment;
            HotKeyData.PropertyChanged += (s, e) => OnPropertyChanged("HotKeyData");
        }

        public bool AutoCloseWindow
        {
            get { return _autoCloseWindow; }
            set
            {
                _autoCloseWindow = value;
                OnPropertyChanged();
            }
        }

        public HotKeyData HotKeyData => _hotKeyData;

        public HorizontalWindowPosition PopupHorizontalPosition
        {
            get { return _popupHorizontalAlignment; }
            set
            {
                _popupHorizontalAlignment = value;
                OnPropertyChanged();
            }
        }

        public VerticalWindowPosition PopupVerticalPosition
        {
            get { return _popupVerticalAlignment; }
            set
            {
                _popupVerticalAlignment = value;
                OnPropertyChanged();
            }
        }

        public static Settings Default => new Settings(false, new HotKeyData(0, false, 0, false, Enum.GetValues(typeof(Key)).Cast<Key>().ToList().IndexOf(Key.F5)), HorizontalWindowPosition.Right, VerticalWindowPosition.Bottom);
    }
}