using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestRequest.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        [JsonProperty(PropertyName = "pantone_value")]
        public string PantoneValue { get; set; } = null!;
    }
}
