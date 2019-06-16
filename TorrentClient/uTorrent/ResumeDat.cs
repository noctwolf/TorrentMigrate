using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BencodeNET.IO;
using BencodeNET.Objects;

namespace TorrentClient.uTorrent
{
    public class ResumeDat : BDictionaryBase
    {
        public ResumeDat(string filePath, BDictionary bDictionary) : base(bDictionary)
        {
            FilePath = filePath;
            Fileguard = bDictionary[".fileguard"].ToString();
            Resumes = bDictionary.Where(f => f.Value is BDictionary)
                .ToDictionary(f => f.Key.ToString(),
                    f => new ResumeInfo(this, f.Key.ToString(), f.Value as BDictionary));
        }

        string FilePath { get; }

        public string Fileguard { get; }

        public IDictionary<string, ResumeInfo> Resumes { get; }
    }
}
