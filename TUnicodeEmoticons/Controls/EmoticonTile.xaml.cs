using System.Windows;

namespace TUnicodeEmoticons.Controls
{
    /// <summary>
    /// Interaction logic for EmoticonTile.xaml
    /// </summary>
    public partial class EmoticonTile : ITile
    {
        public string Text { get; set; }

        public EmoticonTile()
        {
            InitializeComponent();
        }

        public EmoticonTile(string text, string toolTipText)
        {
            InitializeComponent();
            ToolTip = toolTipText;
            Text = text;
            TileContentBlock.Text = text;
        }

        public void InvokeAction()
        {
            Clipboard.SetText(Text);
        }
    }
}