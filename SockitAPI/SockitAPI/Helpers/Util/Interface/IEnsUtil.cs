using SockitAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SockitAPI.Helpers.Util.Interface
{
    public interface IEnsUtil
    {
        string GetNameHashFromMainNet(string addr);
        Task<List<ENSHistoryDomain>> GetHistoryByAddressAndTimeFromAsync(SearchParameter searchParameter);
        Task<List<TransactionDomain>> GetTransactionsByBlockNumberAsync(SearchParameter searchParameter);
    }
}