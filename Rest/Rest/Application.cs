using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestRequest.Services.Abstractions;

namespace RestRequest
{
    public class Application
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly ILogger _logger;
        public Application(
            IAuthenticationService authenticationService,
            IUserService userService,
            IResourceService resourceService,
            ILogger<Application> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _resourceService = resourceService;
            _logger = logger;
        }

        public async Task Start()
        {
            var user2 = await _userService.GetUserAsync(2);
            _logger.LogInformation(JsonConvert.SerializeObject(user2));

            var usersList = await _userService.GetListUsersOnPageAsync(2);
            _logger.LogInformation(JsonConvert.SerializeObject(usersList));

            var delayUsersList = await _userService.UserDelayAsync(3);
            _logger.LogInformation(JsonConvert.SerializeObject(delayUsersList));

            var user23 = await _userService.GetUserAsync(23);
            _logger.LogInformation(JsonConvert.SerializeObject(user23));

            var listResource = await _resourceService.GetAllResourcesAsync();
            _logger.LogInformation(JsonConvert.SerializeObject(listResource));

            var singleResource = await _resourceService.GetResourceAsync(2);
            _logger.LogInformation(JsonConvert.SerializeObject(singleResource));

            var singleResourceNotFound = await _resourceService.GetResourceAsync(23);
            _logger.LogInformation(JsonConvert.SerializeObject(singleResourceNotFound));

            var resultMike = await _userService.CreateUserAsync("Mike", "SysAdmin");
            _logger.LogInformation(JsonConvert.SerializeObject(resultMike));

            if (resultMike != null)
            {
                var updateUser = await _userService.UpdateUserAsync("morpheus", "zion resident", resultMike.Id);
                _logger.LogInformation(JsonConvert.SerializeObject(updateUser));

                await _userService.DeleteUserAsync(resultMike.Id);
            }

            var registerSuccessful = await _authenticationService.RegisterAsync("eoe@ggwp.com", "riotgames");
            _logger.LogInformation(JsonConvert.SerializeObject(registerSuccessful));

            var registerUnuccessful = await _authenticationService.RegisterAsync("eoe@ggwp.com");
            _logger.LogInformation(JsonConvert.SerializeObject(registerUnuccessful));

            var loginSuccessful = await _authenticationService.LoginAsync("eoe@ggwp.com", "riotgames");
            _logger.LogInformation(JsonConvert.SerializeObject(loginSuccessful));

            var loginUnuccessful = await _authenticationService.LoginAsync("eoe@ggwp.com");
            _logger.LogInformation(JsonConvert.SerializeObject(loginSuccessful));
        }
    }
}
