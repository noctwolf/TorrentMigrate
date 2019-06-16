using System;
using System.Collections.Generic;
using System.Text;
using BencodeNET.Objects;

namespace TorrentClient.uTorrent
{
    public class ResumeInfo : BDictionaryBase
    {
        public ResumeInfo(ResumeDat resumeDat, string fileName, BDictionary bDictionary) : base(bDictionary)
        {
            ResumeDat = resumeDat;
            FileName = fileName;
        }

        public ResumeDat ResumeDat { get; }

        public string FileName { get; }

        public string Caption => Get();
    }
}
