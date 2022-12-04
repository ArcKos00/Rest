using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestRequest.Services.Abstractions
{
    public interface IInternalHttpClientService
    {
        public Task<TResponse> SendAsync<TRequest, TResponse>(string url, HttpMethod method, TRequest request = null!)
        where TRequest : class;
    }
}
