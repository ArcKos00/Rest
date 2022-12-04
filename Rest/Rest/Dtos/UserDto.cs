using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestRequest.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; } = null!;
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; } = null!;
        public string Avatar { get; set; } = null!;
    }
}
