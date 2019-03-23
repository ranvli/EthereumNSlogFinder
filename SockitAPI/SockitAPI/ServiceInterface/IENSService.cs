using SockitAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SockitAPI.ServiceInterface
{
    [ServiceContract]
    interface IENSService : IBaseService<ENSHistoryDomain>
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetHistoryAny?p={param}", Method = "GET", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ENSHistoryDomain> GetHistoryAny(SearchParameter param);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetHistoryByENAndTimeFrom?p={param}", Method = "GET", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ENSHistoryDomain> GetHistoryByENAndTimeFrom(SearchParameter param);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetHistoryByAddressAndTimeFrom?p={param}", Method = "GET", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ENSHistoryDomain> GetHistoryByAddressAndTimeFrom(SearchParameter param);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetTransactionsByBlockNumber?p={param}", Method = "GET", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<TransactionDomain> GetTransactionsByBlockNumber(SearchParameter param);
    }
}
