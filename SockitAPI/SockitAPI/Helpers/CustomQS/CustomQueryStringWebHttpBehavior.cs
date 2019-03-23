using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;

namespace SockitAPI.Helpers.CustomQS
{
    public class CustomQueryStringWebHttpBehavior : WebHttpBehavior
    {
        WebMessageFormat defaultOutgoingResponseFormat;
        public CustomQueryStringWebHttpBehavior()
        {
            this.defaultOutgoingResponseFormat = WebMessageFormat.Json;
        }

        public override WebMessageFormat DefaultOutgoingResponseFormat
        {
            get
            {
                return this.defaultOutgoingResponseFormat;
            }
            set
            {
                this.defaultOutgoingResponseFormat = value;
            }
        }

        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new CustomQueryStringConverter();
        }
    }
}