using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BencodeNET.IO;
using BencodeNET.Objects;

namespace TorrentClient.uTorrent
{
    public class ResumeDat
    {
        public string Fileguard { get; set; }

        public IDictionary<string, ResumeInfo> Resumes { get; set; }

        public static explicit operator ResumeDat(BDictionary bDictionary)
        {
            return new ResumeDat()
            {
                Fileguard = bDictionary[".fileguard"].ToString(),
                Resumes = bDictionary.Where(f => f.Value is BDictionary)
                    .ToDictionary(f => f.Key.ToString(), f => (ResumeInfo)(f.Value as BDictionary))
            };
        }
    }
}
