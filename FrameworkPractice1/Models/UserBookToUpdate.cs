using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLayer.Models
{
    public class UserBookToUpdate
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }
}
