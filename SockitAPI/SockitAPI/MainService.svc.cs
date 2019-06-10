using System.Collections.Generic;
using System.Threading.Tasks;
using SockitAPI.Helpers.Util;
using SockitAPI.Helpers.Util.Interface;
using SockitAPI.Model;
using SockitAPI.ServiceInterface;


namespace SockitAPI
{
    public class MainService : IENSService
    {
        private IEnsUtil ensUtil;

        public MainService()
        {
            ensUtil = new EnsUtil();
        }
        public MainService(IEnsUtil _ensUtil)
        {
            ensUtil = _ensUtil;
        }

        /// <summary>
        /// Gets ENS history by any parameter, could be eth domain or address
        /// </summary>
        /// <param name="searchParameter">Must receive 'Any' parameter with .eth or address value</param>
        /// <returns>History List</returns>
        public async Task<List<ENSHistoryDomain>> GetHistoryAnyAsync(SearchParameter searchParameter)
        {

            if (searchParameter.From <= 0)
            {
                searchParameter.From = 0;
            }
             
            if (searchParameter.Any.EndsWith(".eth"))
            {
                searchParameter.EName = searchParameter.Any;
                return await GetHistoryByENAndTimeFromAsync(searchParameter);
            }
            else if (searchParameter.Any.StartsWith("0x"))
            {
                searchParameter.Address = searchParameter.Any;
                var list = await ensUtil.GetHistoryByAddressAndTimeFromAsync(searchParameter);
                return list;
            }
            else
            {
                return new List<ENSHistoryDomain>() { new ENSHistoryDomain() { Address = searchParameter.Any, NumberOfTransactions = -1 } }; ;
            }

        }

        /// <summary>
        /// Get history by address and time
        /// </summary>
        /// <param name="param">Must receive address parameter and time with value</param>
        /// <returns>History list</returns>
        public async Task<List<ENSHistoryDomain>> GetHistoryByAddressAndTimeFromAsync(SearchParameter param)
        {
            return await ensUtil.GetHistoryByAddressAndTimeFromAsync(param);
        }

        /// <summary>
        /// Get history by .eth domain and time
        /// </summary>
        /// <param name="param">Must receive EName and time parameter with value</param>
        /// <returns>History list</returns>
        public async Task<List<ENSHistoryDomain>> GetHistoryByENAndTimeFromAsync(SearchParameter searchParameter)
        {
            string address = ensUtil.GetNameHashFromMainNet(searchParameter.EName); 

            if (address == null)
            {
                return new List<ENSHistoryDomain>() { new ENSHistoryDomain() { Address = address, NumberOfTransactions = -1 } };
            }

            searchParameter.Address = address;
            var list = await ensUtil.GetHistoryByAddressAndTimeFromAsync(searchParameter);
            return list;
        }

        /// <summary>
        /// Get transactions for a given block
        /// </summary>
        /// <param name="searchParameter">Must receive blockNumber with value</param>
        /// <returns>Transactions history list</returns>
        public async Task<List<TransactionDomain>> GetTransactionsByBlockNumberAsync(SearchParameter searchParameter)
        {
            return await ensUtil.GetTransactionsByBlockNumberAsync(searchParameter);
        }


    }
}
