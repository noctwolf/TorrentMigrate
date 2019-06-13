using System.IO;
using BencodeNET.Parsing;
using BencodeNET.Torrents;
using DevExpress.Mvvm;
using System.Threading;
using System.Threading.Tasks;
using BencodeNET.Objects;
using TorrentClient.uTorrent;

namespace TorrentMigrate.App.ViewModels
{
    public class UTorrentViewModel : BindableBase
    {
        private AsyncCommand startAsyncCommand;

        public AsyncCommand StartAsyncCommand => startAsyncCommand ?? (startAsyncCommand =
                                                     new AsyncCommand(() => Task.Run(Start),
                                                         () => !string.IsNullOrEmpty(TorrentRoot)));

        private void Start()
        {
            var parser = new BencodeParser(); // Default encoding is Encoding.UT8F, but you can specify another if you need to
            var resumeDat = (ResumeDat)parser.Parse<BDictionary>(TorrentRoot);
            for (var i = 0; i < 100; i++)
            {
                if (startAsyncCommand.IsCancellationRequested) break;
                Thread.Sleep(100);
            }
        }

        private string torrentRoot = Properties.Settings.Default.TorrentRoot;
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
