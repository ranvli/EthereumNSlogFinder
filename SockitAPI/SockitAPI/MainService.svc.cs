using Nethereum.ENS.Registrar.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using SockitAPI.Model;
using SockitAPI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Net;

namespace SockitAPI
{
    public class MainService : IENSService
    {

        public List<ENSHistoryDomain> GetHistoryAny(SearchParameter searchParameter)
        {

            if (searchParameter.From <= 0)
            {
                searchParameter.From = 0;
            }
             
            if (searchParameter.Any.EndsWith(".eth"))
            {
                searchParameter.EName = searchParameter.Any;
                return GetHistoryByENAndTimeFrom(searchParameter);
            }
            else if (searchParameter.Any.StartsWith("0x"))
            {
                searchParameter.Address = searchParameter.Any;
                return GetHistoryByAddressAndTimeFrom(searchParameter);
            }
            else
            {
                return new List<ENSHistoryDomain>() { new ENSHistoryDomain() { Address = searchParameter.Any, NumberOfTransactions = -1 } }; ;
            }

        }

        public List<ENSHistoryDomain> GetHistoryByENAndTimeFrom(SearchParameter searchParameter)
        {
            string address = new Helpers.Util.EnsUtil().GetNameHashFromMainNet(searchParameter.EName); 

            if (address == null)
            {
                return new List<ENSHistoryDomain>() { new ENSHistoryDomain() { Address = address, NumberOfTransactions = -1 } };
            }

            searchParameter.Address = address;
            return GetHistoryByAddressAndTimeFrom(searchParameter);
        }

        public List<ENSHistoryDomain> GetHistoryByAddressAndTimeFrom(SearchParameter searchParameter)
        {
            //To connect to infura using .net451 and TLS2 you need to set it in advance
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Connection
            var web3 = new Web3(Helpers.Util.Constants.ETHConnection1);
            var contract = web3.Eth.GetContract(Helpers.Util.Constants.ABI, searchParameter.Address);

            //get types of event BidRevealed
            var eventBidRevealed = contract.GetEvent("BidRevealed");
             
            //retrieve latest block info
            var blocksWithTransactionsLatest = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(BlockParameter.CreateLatest()).Result;
            ulong latestBlock = (ulong)blocksWithTransactionsLatest.Number.Value;
            ulong to = (ulong) blocksWithTransactionsLatest.Timestamp.Value;
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
        }

        public List<TransactionDomain> GetTransactionsByBlockNumber(SearchParameter searchParameter)
        {
            //To connect to infura using .net451 and TLS2 you need to set it in advance
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Connection
            var web3 = new Web3(Helpers.Util.Constants.ETHConnection1);
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
        }


    }
}
