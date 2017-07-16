using System.Windows.Input;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons
{
    public class Settings : PropertyChangedBase
    {
        private bool _autoCloseWindow;
        private HorizontalWindowPosition _popupHorizontalPosition;
        private VerticalWindowPosition _popupVerticalPosition;

        public Settings(bool autoCloseWindow, HotKeyData hotKeyData, HorizontalWindowPosition popupHorizontalAlignment, VerticalWindowPosition popupVerticalAlignment)
        {
            AutoCloseWindow = autoCloseWindow;
            HotKeyData = hotKeyData;
            PopupHorizontalPosition = popupHorizontalAlignment;
            PopupVerticalPosition = popupVerticalAlignment;
            HotKeyData.PropertyChanged += (s, e) => OnPropertyChanged("HotKeyData");
        }

        public bool AutoCloseWindow
        {
            get { return _autoCloseWindow; }
            set { SetProperty(value, ref _autoCloseWindow, nameof(AutoCloseWindow)); }
        }

        public HotKeyData HotKeyData { get; }

        public HorizontalWindowPosition PopupHorizontalPosition
        {
            get { return _popupHorizontalPosition; }
            set { SetProperty(value, ref _popupHorizontalPosition, nameof(PopupHorizontalPosition)); }
        }

        public VerticalWindowPosition PopupVerticalPosition
        {
            get { return _popupVerticalPosition; }
            set { SetProperty(value, ref _popupVerticalPosition, nameof(PopupVerticalPosition)); }
        }

        public static Settings Default => new Settings(true, new HotKeyData(0, false, 0, false, Key.F5), HorizontalWindowPosition.Right, VerticalWindowPosition.Bottom);
    }
}