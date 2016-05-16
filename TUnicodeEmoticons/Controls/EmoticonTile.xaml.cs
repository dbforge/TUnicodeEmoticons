using System;
using System.Windows;
using System.Windows.Controls;

namespace TUnicodeEmoticons.Controls
{
    /// <summary>
    /// Interaction logic for EmoticonTile.xaml
    /// </summary>
    public partial class EmoticonTile : UserControl, ITile
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
            tileContentBlock.Text = text;
        }

        public void InvokeAction()
        {
            Clipboard.SetText(Text);
        }
    }
}