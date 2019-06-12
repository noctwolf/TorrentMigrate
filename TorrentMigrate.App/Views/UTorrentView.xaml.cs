using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TorrentMigrate.App.Views
{
    /// <summary>
    /// Interaction logic for UTorrentView
    /// </summary>
    public partial class UTorrentView : UserControl
    {
        public UTorrentView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                //IsFolderPicker = true,
                InitialDirectory = textBoxTorrentRoot.Text
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxTorrentRoot.Text = dialog.FileName;
                textBoxTorrentRoot.Focus();
            }
        }
    }
}
