using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft;

namespace WebApplication.ServicesConnections
{
    public class AccessWcfService
    {
        private const string ConnectionPath = "http://localhost:17330/MusicService/";
        private HttpWebRequest ServiceRequest;

        public AccessWcfService(string uriTemplate, string webRequestMethod)
        {
            ServiceRequest = (HttpWebRequest)WebRequest.Create(ConnectionPath + uriTemplate);
            ServiceRequest.ContentType = "application/json";
            ServiceRequest.Method = webRequestMethod;
        }

        public AccessWcfService(string uriTemplate, string webRequestMethod, string getParameter)
        {
            string url = string.Format("{0}{1}/{2}", ConnectionPath, uriTemplate, getParameter);
            ServiceRequest = (HttpWebRequest)WebRequest.Create(url);
            ServiceRequest.ContentType = "application/json";
            ServiceRequest.Method = webRequestMethod;
        }

        public string GetJsonFromService()
        {
            HttpWebResponse serviceResponse = (HttpWebResponse)ServiceRequest.GetResponse();

            using (var streamReader = new StreamReader(serviceResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }
        }

        public string SendJsonToService(object obj)
        {
            string json;
            if (obj is string)
            {
                json = (string)obj;
            }
            else
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            using (var streamWriter = new StreamWriter(ServiceRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            string returnMessage = GetJsonFromService();

            return returnMessage;
        }

    }
}