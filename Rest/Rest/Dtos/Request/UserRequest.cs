using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestRequest.Dtos.Request
{
    public class UserRequest
    {
        public string Name { get; set; } = null!;
        public string Job { get; set; } = null!;
    }
}
