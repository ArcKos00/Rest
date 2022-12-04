using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestRequest.Configs;
using RestRequest.Dtos;
using RestRequest.Dtos.Response;
using RestRequest.Services.Abstractions;

namespace RestRequest.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _clientHttp;
        private readonly ILogger<ResourceService> _logger;
        private readonly ApiConfig _apiConfig;
        private readonly string _resourceApi = "/api/unknown/";
        public ResourceService(
            IInternalHttpClientService client,
            ILogger<ResourceService> logger,
            IOptions<ApiConfig> options)
        {
            _clientHttp = client;
            _logger = logger;
            _apiConfig = options.Value;
        }

        public async Task<BaseResponse<ResourceDto>?> GetResourceAsync(int id)
        {
            var result = await _clientHttp.SendAsync<object, BaseResponse<ResourceDto>>(
                $"{_apiConfig.Host}{_resourceApi}{id}",
                HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation($"Resource with id: {id} was found");
            }

            return result;
        }

        public async Task<BaseResponse<List<ResourceDto>>?> GetAllResourcesAsync()
        {
            var result = await _clientHttp.SendAsync<object, BaseResponse<List<ResourceDto>>>(
                $"{_apiConfig.Host}{_resourceApi}",
                HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation("Resources was found");
            }

            return result;
        }
    }
}
