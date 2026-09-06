using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLayer.Models
{
    public class BookStoreUser
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class UserIdentityNumber
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
