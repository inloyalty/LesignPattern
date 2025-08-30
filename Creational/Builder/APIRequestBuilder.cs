using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Builder
{
    public class APIRequest
    {
        public string Endpoint { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> QueryParam { get; set; } = new Dictionary<string, string>();

        public string Body { get; set; }
        public override string ToString()
        {
            return $"{Method} {Endpoint} with headers: {string.Join(", ", Headers.Select(h => $"{h.Key}: {h.Value}"))} and body: {Body}";
        }
    }
    public class APIRequestBuilder
    {
        private APIRequest _request;
        public APIRequestBuilder()
        {
            _request = new APIRequest();
        }

        public APIRequestBuilder AddMethod(string methodName)
        {
            _request.Method = methodName;
            return this;
        }


        public APIRequestBuilder AddEndPoint(string endMethod)
        {
            _request.Endpoint = endMethod;
            return this;
        }

        public APIRequestBuilder AddHeader(string key, string value)
        {
            if (!_request.Headers.ContainsKey(key))
                _request.Headers[key] = value;
            return this;
        }

        public APIRequestBuilder AddQueryParam(string key, string value)
        {
            if (!_request.QueryParam.ContainsKey(key))
                _request.QueryParam[key] = value;
            return this;
        }

        public APIRequestBuilder AddBody(string body)
        {
            _request.Body = body;
            return this;
        }

        public APIRequest build()
        {
            return _request;
        }

    }

    public class APIRequestBuilderTest
    {

        public static void Test()
        {
            var request = new APIRequestBuilder()
                             .AddMethod("POST")
                             .AddEndPoint("http://api.test.com/api/customer")
                             .AddHeader("Accept", "application/json")
                             .AddQueryParam("id", "111")
                             .AddBody("{\"name\":\"John Doe\",\"email\":\"john@example.com\"}")
                             .build();

            Console.WriteLine(request);                             

        }
    }
}
