using System;
using System.Collections.Generic;
using System.Text;
using BencodeNET.Objects;

namespace TorrentClient.uTorrent
{
    public class ResumeInfo
    {
        public static explicit operator ResumeInfo(BDictionary bDictionary)
        {
            return new ResumeInfo();
        }
    }
}
