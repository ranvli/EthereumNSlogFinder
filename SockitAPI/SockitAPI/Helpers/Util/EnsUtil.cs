using Nethereum.ENS;
using Nethereum.ENS.ENSRegistry.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SockitAPI.Helpers.Util
{
    public class EnsUtil
    {
        public string GetLabelHash(string label)
        {
            var kecckak = new Sha3Keccack();
            return kecckak.CalculateHash(label);
        }

        public string GetNameHash(string name)
        {

            var node = "0x0000000000000000000000000000000000000000000000000000000000000000";
            var kecckak = new Sha3Keccack();
            if (!string.IsNullOrEmpty(name))
            {
                name = Normalise(name);
                var labels = name.Split('.');
                for (var i = labels.Length - 1; i >= 0; i--)
                {
                    var byteInput = (node + GetLabelHash(labels[i])).HexToByteArray();
                    node = kecckak.CalculateHash(byteInput).ToHex();
                }
            }
            return node.EnsureHexPrefix();
        }

        public string GetNameHashFromMainNet(string addr)
        {
            //To connect to infura using .net451 and TLS2 you need to set it in advance
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var web3 = new Web3(Constants.ETHConnection1);

            var fullNameNode = new EnsUtil().GetNameHash(addr);

            //Using mainnet to resolve
            var ensRegistryService = new ENSRegistryService(web3, Constants.MAINNET_RESOLVER_ADDRESS);
            //get the resolver address from ENS
            var resolverAddress = ensRegistryService.ResolverQueryAsync(new ResolverFunction() { Node = fullNameNode.HexToByteArray() }).Result;
                        
            var resolverService = new PublicResolverService(web3, resolverAddress);
            
            //and get the address from the resolver
            var x = fullNameNode.HexToByteArray();
            var theAddress = resolverService.AddrQueryAsync(x).Result;

            //Owner address
            return theAddress;
        }

        public string Normalise(string name)
        {
            try
            {
                var idn = new IdnMapping
                {
                    UseStd3AsciiRules = true
                };
                return idn.GetAscii(name).ToLower();

            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Invalid ENS name", ex);
            }
        }
    }
}