namespace TUnicodeEmoticons.Controls
{
    /// <summary>
    /// Interaction logic for ActionTile.xaml
    /// </summary>
    public partial class ActionTile : ITile
    {
        public ActionTile()
        {
            InitializeComponent();
        }

        public ActionTile(string text, string toolTipText)
        {
            InitializeComponent();
            ToolTip = toolTipText;
            TileContentBlock.Text = text;
        }

        public void InvokeAction()
        {
            // Show a new dialog
        }
    }
}