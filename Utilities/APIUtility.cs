using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Utilities
{
    public class APIUtility
    {
        private static RestClient restClient;
        private static RestRequest request;

        public static void SetRestClient(string url)
        {
            restClient = new RestClient(url);
        }
        public static RestRequest GetRestRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }

        public static RestResponse Get(string endpoint, Dictionary<string, string> headers=null, Dictionary<string, string> parameters=null)
        {
            request = new RestRequest(endpoint, Method.Get);
            if (headers != null) AddHeaders(headers);
            if (parameters != null) AddParameters(parameters);
            var response = restClient.Execute(request);
            return response;
        }

        public static RestResponse Post<T>(string endpoint, T body, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            request = new RestRequest(endpoint, Method.Post);
            if (headers != null) AddHeaders(headers);
            if (parameters != null) AddParameters(parameters);
            request.AddJsonBody(JsonConvert.SerializeObject(body));
            var response = restClient.Execute(request);
            return response;
        }

        public static RestResponse Delete<T>(string endpoint, T body, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            request = new RestRequest(endpoint, Method.Delete);
            if (headers != null) AddHeaders(headers);
            if (parameters != null) AddParameters(parameters);
            request.AddJsonBody(JsonConvert.SerializeObject(body));
            var response = restClient.Execute(request);
            return response;
        }

        public static void AddHeaders(Dictionary<string, string> headers)
        {
            foreach(KeyValuePair<string, string> header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
        }

        public static void AddParameters(Dictionary<string, string> parameters)
        {
            foreach(KeyValuePair<string, string> parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
        }

        public static T Deserialize<T>(string responseContent)
        {
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public static int GetResponseCode(RestResponse response)
        {
            return (int)response.StatusCode;
        }

    }
}
