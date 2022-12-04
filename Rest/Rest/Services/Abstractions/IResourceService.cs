using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestRequest.Dtos;
using RestRequest.Dtos.Response;

namespace RestRequest.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<BaseResponse<ResourceDto>?> GetResourceAsync(int id);
        public Task<BaseResponse<List<ResourceDto>>?> GetAllResourcesAsync();
    }
}
