using SockitAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace SockitAPI.Helpers.CustomQS
{
    public class CustomQueryStringConverter : QueryStringConverter
    {
        public override bool CanConvert(Type type)
        {
            if (type.IsArray)
            {
                return base.CanConvert(type.GetElementType());
            }
            else if (type == typeof(SearchParameter))
            {
                return true;
            }
            else
            {
                return base.CanConvert(type);
            }
        }

        public override string ConvertValueToString(object parameter, Type parameterType)
        {
            return base.ConvertValueToString(parameter, parameterType);
        }

        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            if (parameterType.IsArray)
            {
                Type elementType = parameterType.GetElementType();
                string[] parameterList = parameter.Split(',');
                Array result = Array.CreateInstance(elementType, parameterList.Length);
                for (int i = 0; i < parameterList.Length; i++)
                {
                    result.SetValue(base.ConvertStringToValue(parameterList[i], elementType), i);
                }

                return result;
            }
            else if (parameterType == typeof(SearchParameter))
            {

                SearchParameter o = null;
                try
                {
                    o = JsonConvert.DeserializeObject<SearchParameter>(parameter);
                }
                catch (Exception e)
                {

                }

                return o;
            }
            else
            {
                return base.ConvertStringToValue(parameter, parameterType);
            }
        }
    }
}