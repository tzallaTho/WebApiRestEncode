using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApplication2
{
    public class CustomActionResult<T> : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
        public HttpStatusCode statusCode;

        public CustomActionResult(string value, HttpRequestMessage request, HttpStatusCode ssCode)
        {
            _value = value;
            _request = request;
            statusCode = ssCode;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
        // public System.Net.HttpStatusCode statusCode;
        // T data;
        //// string _value;
        // HttpRequestMessage _request;

        // public CustomActionResult( HttpRequestMessage request, HttpStatusCode st,T dd)
        // {
        //     //_value = value;
        //     _request = request;
        //     statusCode = st;
        //     data = dd;
        // }
        // public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        // {
        //     var response = new HttpResponseMessage()
        //     {
        //         Content = new StringContent(data.ToString()),
        //         RequestMessage = _request
        //     };
        //     return Task.FromResult(response);
        // }


    }
}