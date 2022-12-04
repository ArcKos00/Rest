using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestRequest;
using RestRequest.Configs;
using RestRequest.Services;
using RestRequest.Services.Abstractions;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();
var collection = new ServiceCollection();
ConfigurationService(collection, config);
var provider = collection.BuildServiceProvider();

var app = provider.GetService<Application>();
await app!.Start();

void ConfigurationService(ServiceCollection services, IConfiguration configuration)
{
    services.AddOptions<ApiConfig>().Bind(configuration.GetSection("Api"));
    services.AddLogging(config => config.AddConsole())
        .AddHttpClient()
        .AddTransient<IAuthenticationService, AuthenticationService>()
        .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
        .AddTransient<IResourceService, ResourceService>()
        .AddTransient<IUserService, UserService>()
        .AddTransient<Application>();
}