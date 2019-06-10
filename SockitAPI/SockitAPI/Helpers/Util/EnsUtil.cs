using Nethereum.ENS;
using Nethereum.ENS.ENSRegistry.ContractDefinition;
using Nethereum.ENS.Registrar.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using SockitAPI.Helpers.Util.Interface;
using SockitAPI.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace SockitAPI.Helpers.Util
{
    public class EnsUtil : IEnsUtil
    {
        private IEnsUtil ensUtil;

        public EnsUtil()
        {
            ensUtil = new EnsUtil();
        }
        public EnsUtil(IEnsUtil _ensUtil)
        {
            ensUtil = _ensUtil;
        }

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

        public async Task<List<ENSHistoryDomain>> GetHistoryByAddressAndTimeFromAsync(SearchParameter searchParameter)
        {
            return await Task.Run(() =>
            {
                //To connect to infura using .net451 and TLS2 you need to set it in advance
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //Connection
                var web3 = new Web3(Constants.ETHConnection1);
                var contract = web3.Eth.GetContract(Constants.ABI, searchParameter.Address);

                //get types of event BidRevealed
                var eventBidRevealed = contract.GetEvent("BidRevealed");

                //retrieve latest block info
                var blocksWithTransactionsLatest = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(BlockParameter.CreateLatest()).Result;
                ulong latestBlock = (ulong)blocksWithTransactionsLatest.Number.Value;
                ulong to = (ulong)blocksWithTransactionsLatest.Timestamp.Value;

                //DateTime lastestDate = UnixTimeStampToDateTime(latestTimeStamp);

                //go back till get from
                ulong fromBlock = latestBlock - 1;
                ulong currentDate;
                List<ENSHistoryDomain> ensHistoryDomains = new List<ENSHistoryDomain>();
                do
                {
                    var blocksWithTransactions = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(fromBlock), new BlockParameter(latestBlock)).Result;
                    currentDate = (ulong)blocksWithTransactions.Timestamp.Value;
                    fromBlock -= 1000;
                } while (searchParameter.From <= currentDate);


                var filterInput = eventBidRevealed.CreateFilterInput(new BlockParameter(fromBlock), BlockParameter.CreateLatest());
                var logs = eventBidRevealed.GetAllChanges<BidRevealedEventDTOBase>(filterInput).Result;

                foreach (var log in logs)
                {
                    //double check date by retrieving the block number from eth api
                    //at the very same time if it is within the range of date then create list to retrun
                    var blocksWithTransactions = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(log.Log.BlockNumber)).Result;
                    currentDate = (ulong)blocksWithTransactions.Timestamp.Value;
                    if (searchParameter.From <= currentDate)
                    {
                        ENSHistoryDomain ensHistory = new ENSHistoryDomain();
                        ensHistory.Address = searchParameter.Address;
                        ensHistory.TimeStamp = (ulong)blocksWithTransactions.Timestamp.Value;
                        ensHistory.BlockHash = blocksWithTransactions.BlockHash;
                        ensHistory.BlockNumber = (ulong)blocksWithTransactions.Number.Value;
                        ensHistory.NumberOfTransactions = blocksWithTransactions.Transactions.Length;
                        ensHistory.Author = blocksWithTransactions.Author;
                        ensHistoryDomains.Add(ensHistory);
                    }
                }

                if (ensHistoryDomains.Count == 0)
                {
                    return new List<ENSHistoryDomain>() { new ENSHistoryDomain() { Address = searchParameter.Address, NumberOfTransactions = -2 } };
                }

                return ensHistoryDomains;
            });

        }

        public async Task<List<TransactionDomain>> GetTransactionsByBlockNumberAsync(SearchParameter searchParameter)
        {
            return await Task.Run(() =>
            {
                //To connect to infura using .net451 and TLS2 you need to set it in advance
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //Connection
                var web3 = new Web3(Constants.ETHConnection1);
                var blocksWithTransactions = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(searchParameter.BlockNumber)).Result;

                List<TransactionDomain> transactionsDomains = new List<TransactionDomain>();

                foreach (var transaction in blocksWithTransactions.Transactions)
                {
                    TransactionDomain transactionDomain = new TransactionDomain();
                    transactionDomain.From = transaction.From;
                    transactionDomain.To = transaction.To;
                    transactionDomain.Value = transaction.Value.Value.ToString();
                    transactionDomain.TransactionHash = transaction.TransactionHash;
                    transactionDomain.TransactionIndex = (Int64)transaction.TransactionIndex.Value;
                    transactionDomain.Gas = (Int64)transaction.Gas.Value;
                    transactionDomain.GasPrice = (Int64)transaction.GasPrice.Value;
                    transactionDomain.Input = transaction.Input;
                    transactionsDomains.Add(transactionDomain);
                }

                return transactionsDomains;
            });
        }
    }
}