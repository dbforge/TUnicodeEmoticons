using System.Collections.ObjectModel;
using System.Linq;
using TUnicodeEmoticons.Controls;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private static MainViewModel _instance;
        public static MainViewModel Instance => _instance ?? (_instance = new MainViewModel());

        private MainViewModel()
        {
            Tiles =
                new ObservableCollection<ITile>(Session.TileData.Select(x => new EmoticonTile(x.Text, x.ToolTip)))
                {
                    new ActionTile("+", "Add an emoticon...")
                };
        }

        private ObservableCollection<ITile> _tiles;
        public ObservableCollection<ITile> Tiles
        {
            get { return _tiles; }
            set { SetProperty(value, ref _tiles, nameof(Tiles)); }
        }
    }
}