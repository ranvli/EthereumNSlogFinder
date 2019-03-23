using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nethereum.Hex.HexTypes;

namespace SockitAPI.Model
{
    public class TransactionDomain
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
        public string TransactionHash { get; set; }
        public Int64 TransactionIndex { get; set; }
        public Int64 Gas { get; set; }
        public Int64 GasPrice { get; set; }
        public string Input { get; set; }
    }
}