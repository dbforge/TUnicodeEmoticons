using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using TUnicodeEmoticons.Views;
using Application = System.Windows.Application;

namespace TUnicodeEmoticons
{
    public static class Session
    {
        private static bool _hotKeyInitialized;
        private static HotKey _hotKey;

        private static readonly ObservableCollection<string> FirstKeyCollection =
            new ObservableCollection<string> {"Control", "Alt"};

        private static readonly ObservableCollection<string> SecondKeyCollection =
            new ObservableCollection<string> {"Shift", "Win"};

        private static NotifyIcon _notifyIcon;
        public static Settings Settings { get; private set; }

        public static TrulyObservableCollection<TileData> TileData { get; private set; }

        private static void ExitMenuItemClick(object sender, EventArgs e)
        {
            _hotKey.Dispose();
            _notifyIcon.Dispose();
            Application.Current.Shutdown();
        }

        public static void InitializeData()
        {
            if (!Directory.Exists(FilePathProvider.AppDataPath))
                Directory.CreateDirectory(FilePathProvider.AppDataPath);
            if (!File.Exists(FilePathProvider.TileDataFile))
                File.WriteAllText(FilePathProvider.TileDataFile,
                    JsonConvert.SerializeObject(TUnicodeEmoticons.TileData.Default));
            if (!File.Exists(FilePathProvider.SettingsDataFile))
                File.WriteAllText(FilePathProvider.SettingsDataFile, JsonConvert.SerializeObject(Settings.Default),
                    Encoding.Unicode);

            TileData =
                JsonConvert.DeserializeObject<TrulyObservableCollection<TileData>>(File.ReadAllText(FilePathProvider
                    .TileDataFile));
            TileData.CollectionChanged += (sender, args) =>
            {
                File.WriteAllText(FilePathProvider.TileDataFile, JsonConvert.SerializeObject(TileData));
            };

            Settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(FilePathProvider.SettingsDataFile));
            Settings.PropertyChanged += (sender, args) =>
            {
                File.WriteAllText(FilePathProvider.SettingsDataFile, JsonConvert.SerializeObject(Settings));
                if (args.PropertyName == "HotKeyData")
                    InitializeHotKey();
            };
        }

        public static void InitializeHotKey()
        {
            // If an old one is registered, save the new one.
            if (_hotKeyInitialized)
                _hotKey.Dispose();

            var keyData = Settings.HotKeyData;
            var modifiers = KeyModifiers.None;
            if (keyData.HasFirstModifier)
                modifiers |= (KeyModifiers) Enum.Parse(typeof(KeyModifiers),
                    FirstKeyCollection[keyData.FirstModifierIndex]);
            if (keyData.HasSecondModifier)
                modifiers |= (KeyModifiers) Enum.Parse(typeof(KeyModifiers),
                    SecondKeyCollection[keyData.SecondModifierIndex]);

            _hotKey = new HotKey(keyData.Key, modifiers, false)
            {
                Action = h => MainWindow.Instance.Show()
            };

            if (!_hotKey.Register())
                throw new Exception("Could not initialize hotkey.");
            _hotKeyInitialized = true;
        }

        public static void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            var streamResourceInfo =
                Application.GetResourceStream(
                    new Uri("pack://application:,,,/TUnicodeEmoticons;component/Icons/TUnicodeEmoticons.ico"));
            if (streamResourceInfo == null)
                throw new Exception("Could not load icon.");

            using (var iconStream = streamResourceInfo.Stream)
            {
                _notifyIcon.Icon = new Icon(iconStream);
            }

            var menuItems = new MenuItem[2];
            menuItems[0] = new MenuItem("Settings");
            menuItems[0].Click += SettingsMenuItemClick;

            menuItems[1] = new MenuItem("Exit");
            menuItems[1].Click += ExitMenuItemClick;
            _notifyIcon.ContextMenu = new ContextMenu(menuItems);

            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(5000, "TUnicodeEmoticons", "TUnicodeEmoticons is now ready for use.",
                ToolTipIcon.None);
        }

        private static void SettingsMenuItemClick(object sender, EventArgs e)
        {
            SettingsWindow.Instance.Show();
        }
    }
}