using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BencodeNET.Objects;

namespace TorrentClient
{
    public class BDictionaryBase
    {
        public BDictionaryBase(BDictionary bDictionary)
        {
            BDictionary = bDictionary;
        }

        public BDictionary BDictionary { get; }

        public IBObject GetBObject([CallerMemberName] string keyName = "") => BDictionary.Value[keyName.ToLower()];

        public string Get([CallerMemberName] string keyName = "") => GetBObject(keyName).ToString();
    }
}
