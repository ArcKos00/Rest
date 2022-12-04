using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestRequest.Dtos.Response
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;
        public string Error { get; set; } = null!;
    }
}
