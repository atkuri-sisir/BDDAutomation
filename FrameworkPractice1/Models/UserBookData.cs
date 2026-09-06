using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLayer.Models
{
    public class UserBookId
    {
        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }
    public class UserBookData
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("collectionOfIsbns")]
        public List<UserBookId> Isbns { get; set; }
    }

    public class UserBooks
    {
        [JsonProperty("collectionOfIsbns")]
        public List<UserBookId> Isbns { get; set; }
    }
}
