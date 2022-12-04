using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestRequest.Configs;
using RestRequest.Dtos;
using RestRequest.Dtos.Request;
using RestRequest.Dtos.Response;
using RestRequest.Services.Abstractions;

namespace RestRequest.Services
{
    public class UserService : IUserService
    {
        private readonly ApiConfig _apiConfig;
        private readonly ILogger<UserService> _logger;
        private readonly IInternalHttpClientService _clientHttp;
        private readonly string _userApi = "/api/users/";
        public UserService(
            IOptions<ApiConfig> options,
            ILogger<UserService> logger,
            IInternalHttpClientService client)
        {
            _apiConfig = options.Value;
            _logger = logger;
            _clientHttp = client;
        }

        public async Task<UserResponse?> CreateUserAsync(string name, string job)
        {
            var result = await _clientHttp.SendAsync<UserRequest, UserResponse>(
                $"{_apiConfig.Host}{_userApi}",
                HttpMethod.Post,
                new UserRequest()
                {
                    Name = name,
                    Job = job
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id: {result?.Id} was created");
            }

            return result;
        }

        public async Task<BaseResponse<UserDto>?> GetUserAsync(int id)
        {
            var result = await _clientHttp.SendAsync<object, BaseResponse<UserDto>>($"{_apiConfig.Host}{_userApi}{id}", HttpMethod.Get);

            if (result != null)
            {
                _logger.LogInformation($"User with id: {id} was found");
            }
            else
            {
                return null!;
            }

            return result;
        }

        public async Task<BaseResponse<List<UserDto>>?> GetListUsersOnPageAsync(int page)
        {
            var result = await _clientHttp.SendAsync<object, BaseResponse<List<UserDto>>>(
                $"{_apiConfig.Host}{_userApi}?page={page}",
                HttpMethod.Get);
            if (result != null)
            {
                _logger.LogInformation($"Users on {page} page was found");
            }
            else
            {
                return null!;
            }

            return result;
        }

        public async Task<UserResponse?> UpdateUserAsync(string name, string job, int id)
        {
            var result = await _clientHttp.SendAsync<UserRequest, UserResponse>(
                $"{_apiConfig.Host}{_userApi}{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Name = name,
                    Job = job
                });
            if (result != null)
            {
                _logger.LogInformation($"Update user with id: {id} was successful");
            }

            return result;
        }

        public async Task DeleteUserAsync(int id)
        {
            var result = await _clientHttp.SendAsync<object, string>(
                $"{_apiConfig.Host}{_userApi}{id}",
                HttpMethod.Delete);
            if (result == string.Empty)
            {
                _logger.LogInformation($"Delete user with id{id} was successful");
            }
        }

        public async Task<BaseResponse<List<UserDto>>?> UserDelayAsync(int page)
        {
            var result = await _clientHttp.SendAsync<object, BaseResponse<List<UserDto>>>(
                $"{_apiConfig.Host}{_userApi}?delay={page}",
                HttpMethod.Get);
            if (result != null)
            {
                _logger.LogInformation($"Users on {page} page was found");
            }
            else
            {
                return null!;
            }

            return result;
        }
    }
}
