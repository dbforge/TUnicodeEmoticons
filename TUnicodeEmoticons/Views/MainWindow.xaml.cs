using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TUnicodeEmoticons.Controls;
using TUnicodeEmoticons.ViewModels;
using static System.String;

namespace TUnicodeEmoticons.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null || PresentationSource.FromVisual(_instance) == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            switch (Session.Settings.PopupHorizontalPosition)
            {
                case HorizontalWindowPosition.Left:
                    Left = desktopWorkingArea.Left;
                    break;
                case HorizontalWindowPosition.Right:
                    Left = desktopWorkingArea.Right - Width;
                    break;
                case HorizontalWindowPosition.Center:
                    Left = desktopWorkingArea.Right / 2 - Width / 2;
                    break;
            }

            switch (Session.Settings.PopupVerticalPosition)
            {
                case VerticalWindowPosition.Top:
                    Top = desktopWorkingArea.Top;
                    break;
                case VerticalWindowPosition.Bottom:
                    Top = desktopWorkingArea.Bottom - Height;
                    break;
                case VerticalWindowPosition.Center:
                    Top = desktopWorkingArea.Bottom / 2 - Height / 2;
                    break;
            }
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = EmoticonListBox.SelectedIndex;
            if (index != -1)
                MainViewModel.Instance.Tiles[index].InvokeAction();

            if (Session.Settings.AutoCloseWindow)
                Close();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsNullOrWhiteSpace(SearchTextBox.Text))
                MainViewModel.Instance.Tiles = new ObservableCollection<ITile>(Session.TileData.Select(x => new EmoticonTile(x.Text, x.ToolTip)))
                {
                    new ActionTile("+", "Add an emoticon...")
                };
            else
            {
                MainViewModel.Instance.Tiles.Clear();
                MainViewModel.Instance.Tiles = new ObservableCollection<ITile>(Session.TileData.Where(t => t.Text.Contains(SearchTextBox.Text) || t.ToolTip.Contains(SearchTextBox.Text)).Select(x => new EmoticonTile(x.Text, x.ToolTip)))
                {
                    new ActionTile("+", "Add an emoticon...")
                };
            }
        }
    }
}