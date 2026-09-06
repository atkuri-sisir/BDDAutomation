using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLayer.Models
{
    public class SauceDemoUser
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class SauceDemoUsersList
    {
        [JsonProperty("logincredentials")]
        public List<SauceDemoUser> LoginCredentials { get; set; }
    }
}
