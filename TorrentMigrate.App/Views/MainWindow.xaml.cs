using System.Windows;
using Prism.Regions;

namespace TorrentMigrate.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegionManager.GetRegionManager(this).RequestNavigate("ContentRegion", nameof(UTorrentView));
        }
    }
}
