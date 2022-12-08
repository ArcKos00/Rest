using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Dtos.Response;
using RestRequest.Dtos;
using RestRequest.Dtos.Response;

namespace RestRequest.Services.Abstractions
{
    public interface IUserService
    {
        public Task<Pager<List<UserDto>>?> GetListUsersOnPageAsync(int page);
        public Task<BaseResponse<UserDto>?> GetUserAsync(int id);
        public Task<UserResponse?> CreateUserAsync(string name, string job);
        public Task<UserResponse?> UpdateUserAsync(string name, string job, int id);
        public Task DeleteUserAsync(int id);
        public Task<Pager<List<UserDto>>?> UserDelayAsync(int page);
    }
}
