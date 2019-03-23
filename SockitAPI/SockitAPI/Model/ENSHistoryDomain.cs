using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nethereum.Hex.HexTypes;

namespace SockitAPI.Model
{
    public class ENSHistoryDomain
    {
        public ulong TimeStamp { get; set; }
        public ulong BlockNumber { get; set; }
        public string Author { get; set; }
        public int NumberOfTransactions { get; set; }
        public string BlockHash { get; set; }
        public string Address { get;  set; }
    }
}