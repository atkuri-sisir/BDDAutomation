using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using RestSharp;
using Utilities;

namespace FrameworkLayer.Models
{
    public class CreatedBookstoreUser
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("books")]
        public List<BookData> Books { get; set; }

        public static void UpdateUserId(CreatedBookstoreUser user)
        {
            var userData = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\TestData\\UserId.json");
            var userObject = JsonConvert.DeserializeObject<UserIdentityNumber>(userData);
            userObject.UserId = user.UserId;
            userData = JsonConvert.SerializeObject(userObject);
            string dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string jsonFilePath = dir.Replace("bin\\Debug\\net6.0", "TestData\\UserId.json");
            File.WriteAllText(jsonFilePath, userData);
        }
    }
}
