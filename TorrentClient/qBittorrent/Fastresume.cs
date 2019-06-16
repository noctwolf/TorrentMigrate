using System;
using System.Collections.Generic;
using System.Text;
using BencodeNET.Objects;

namespace TorrentClient.qBittorrent
{
    public class Fastresume : BDictionaryBase
    {
        public Fastresume(BDictionary bDictionary) : base(bDictionary)
        {
        }

        public Fastresume() : base(new BDictionary())
        {
        }
    }
}
