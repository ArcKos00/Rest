using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestRequest.Configs;
using RestRequest.Dtos.Request;
using RestRequest.Dtos.Response;
using RestRequest.Services.Abstractions;

namespace RestRequest.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IInternalHttpClientService _clientHttp;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly ApiConfig _apiConfig;
        private readonly string _login = "/api/login";
        private readonly string _register = "/api/register";
        public AuthenticationService(
            IInternalHttpClientService client,
            ILogger<AuthenticationService> logger,
            IOptions<ApiConfig> options)
        {
            _clientHttp = client;
            _logger = logger;
            _apiConfig = options.Value;
        }

        public async Task<AuthenticationResponse?> LoginAsync(string email, string password = null!)
        {
            var result = await _clientHttp.SendAsync<AuthenticationRequest, Pager<AuthenticationResponse>>(
                $"{_apiConfig.Host}{_login}",
                HttpMethod.Post,
                new AuthenticationRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result.Data?.Error == null)
            {
                _logger.LogWarning("Authentication is successful");
            }

            return result?.Data;
        }

        public async Task<AuthenticationResponse?> RegisterAsync(string email, string password = null!)
        {
            var result = await _clientHttp.SendAsync<AuthenticationRequest, Pager<AuthenticationResponse>>(
                $"{_apiConfig.Host}{_register}",
                HttpMethod.Post,
                new AuthenticationRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result.Data?.Error == null)
            {
                _logger.LogWarning("Authentication is successful");
            }

            return result?.Data;
        }
    }
}
