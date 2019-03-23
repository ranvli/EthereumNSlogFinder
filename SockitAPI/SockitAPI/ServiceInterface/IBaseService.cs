using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SockitAPI.ServiceInterface
{
    /// <summary>
    /// Base Service interface
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    [ServiceContract]
    public interface IBaseService<T>
    {


    }
}
