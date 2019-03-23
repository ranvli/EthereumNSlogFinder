using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SockitAPI.Model
{
    public class SearchParameter
    {
        public string Address { get; set; }
        public ulong From { get; set; }
        public string EName { get; set; }
        public ulong BlockNumber { get; set; }
        public string Any { get; set; }
    }
}