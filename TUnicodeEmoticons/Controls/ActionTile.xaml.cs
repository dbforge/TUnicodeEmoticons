using System.Windows.Controls;

namespace TUnicodeEmoticons.Controls
{
    /// <summary>
    /// Interaction logic for ActionTile.xaml
    /// </summary>
    public partial class ActionTile : UserControl, ITile
    {
        public ActionTile()
        {
            InitializeComponent();
        }

        public ActionTile(string text, string toolTipText)
        {
            InitializeComponent();
            ToolTip = toolTipText;
            tileContentBlock.Text = text;
        }

        public void InvokeAction()
        {
            // Show a new dialog
        }
    }
}