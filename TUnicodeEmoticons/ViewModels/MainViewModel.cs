using System.Collections.ObjectModel;
using System.Linq;
using TUnicodeEmoticons.Controls;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private static MainViewModel _instance;
        public static MainViewModel MainStatic
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();
                return _instance;
            }
        }

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
            get
            {
                return _tiles;
            }
            set
            {
                _tiles = value;
                OnPropertyChanged();
            }
        }
    }
}