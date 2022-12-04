using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestRequest.Dtos.Response
{
    public class UserResponse
    {
        public string Name { get; set; } = null!;
        public string Job { get; set; } = null!;
        public int Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public DateTimeOffset UpdateAt { get; set; }
    }
}
