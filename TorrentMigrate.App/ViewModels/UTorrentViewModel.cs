using DevExpress.Mvvm;
using System.Threading;
using System.Threading.Tasks;

namespace TorrentMigrate.App.ViewModels
{
    public class UTorrentViewModel : BindableBase
    {
        private AsyncCommand startAsyncCommand;
        public AsyncCommand StartAsyncCommand => startAsyncCommand ?? (startAsyncCommand = new AsyncCommand(() => Task.Run(Start), () => !string.IsNullOrEmpty(TorrentRoot)));

        private void Start()
        {
            for (var i = 0; i < 100; i++)
            {
                if (startAsyncCommand.IsCancellationRequested) break;
                Thread.Sleep(100);
            }
        }

        string torrentRoot = Properties.Settings.Default.TorrentRoot;
        public string TorrentRoot
        {
            get => torrentRoot;
            set
            {
                if (!SetProperty(ref torrentRoot, value, nameof(TorrentRoot))) return;
                Properties.Settings.Default.TorrentRoot = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
