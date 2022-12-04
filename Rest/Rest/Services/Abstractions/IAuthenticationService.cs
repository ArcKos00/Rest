using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestRequest.Dtos.Response;

namespace RestRequest.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse?> RegisterAsync(string email, string password = null!);
        public Task<AuthenticationResponse?> LoginAsync(string email, string password = null!);
    }
}
