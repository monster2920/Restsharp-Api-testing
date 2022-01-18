using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SwagRestApi
{
    internal class RestCommon
    {
        static RestClient client;
        static RestRequest request;
        static IRestResponse response;
        static HttpStatusCode code;
        internal static void InitializeClient(string baseURL, string endpoint)
        {
          string uri = Path.Combine(baseURL + endpoint);
             client = new RestClient(uri);
        }

        internal static void CreateRequest(Method methodName)
        {
            request = new RestRequest(methodName);
        }

        internal static void AddUrlParameter(int urlParam)
        {
            request.AddUrlSegment("id",urlParam);
        }

        internal static void Execute()
        {
            response= client.Execute(request);
        }

        internal static void ValidateResponseContent(string expectedtext)
        {
            Console.WriteLine(expectedtext);
            Console.WriteLine(response.StatusCode);
            Assert.IsTrue(response.Content.Contains(expectedtext),"the expected text is missing in response content");
            
        }

        internal static void AddRequestBody(string requestJsonBody)
        {
            request.AddJsonBody(requestJsonBody);
        }

        internal static void ValidateResponseCode(string expected)
        {
            string actual = response.StatusCode.ToString();
            Assert.AreEqual(expected,actual);
        }

        internal static void ValidatehttpsCode(int expected)
        {
            code = response.StatusCode;
            int actual = (int)code;
            Assert.AreEqual(expected, actual);
        }
    }
}
