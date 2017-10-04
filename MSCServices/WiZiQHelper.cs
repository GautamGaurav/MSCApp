using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using MSCCommon;

/// <summary>
/// Summary description for WiZiQHelper
/// </summary>
namespace MSCServices
{
    public class WiZiQHelper
    {
        public WiZiQHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetSignature(string method)
        {
            string accessKey = ConfigurationManager.AppSettings["AccessKey"];
            string secretAcessKey = ConfigurationManager.AppSettings["SeceretKey"];
            string timestamp = AuthBase.GenerateTimeStamp();
            AuthBase authBase = new AuthBase();
            string signature = authBase.GenerateSignature(accessKey, secretAcessKey, timestamp, method);
            return signature;
        }

        public static string MakeRequest(string method, Dictionary<string, string> requestParameters)
        {
            requestParameters["method"] = method;
            requestParameters["access_key"] = ConfigurationManager.AppSettings["AccessKey"];
            requestParameters["timestamp"] = AuthBase.GenerateTimeStamp();

            requestParameters["signature"] = WiZiQHelper.GetSignature(method);
            string serviceRootUrl = ConfigurationManager.AppSettings["ServiceRootUrl"];
            MSCServices.HttpRequest oRequest = new MSCServices.HttpRequest();
            return oRequest.WiZiQWebRequest(serviceRootUrl + "method=" + method + "", requestParameters);
        }

        public static string MakeRequest(string method, NameValueCollection requestParameters, string postFilePath)
        {
            requestParameters["method"] = method;
            requestParameters["access_key"] = ConfigurationManager.AppSettings["AccessKey"];
            requestParameters["timestamp"] = AuthBase.GenerateTimeStamp();

            requestParameters["signature"] = WiZiQHelper.GetSignature(method);
            string serviceRootUrl = ConfigurationManager.AppSettings["ServiceRootUrl"];
            MSCServices.HttpRequest oRequest = new MSCServices.HttpRequest();
            return oRequest.WiZiQWebRequest(serviceRootUrl + "method=" + method + "", requestParameters, postFilePath);
        }
    }
}