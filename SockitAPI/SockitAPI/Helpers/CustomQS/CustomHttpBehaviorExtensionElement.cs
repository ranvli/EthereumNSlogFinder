using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SockitAPI.Helpers.CustomQS
{
    public class CustomHttpBehaviorExtensionElement : System.ServiceModel.Configuration.BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new CustomQueryStringWebHttpBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(CustomQueryStringWebHttpBehavior); }
        }
    }
}