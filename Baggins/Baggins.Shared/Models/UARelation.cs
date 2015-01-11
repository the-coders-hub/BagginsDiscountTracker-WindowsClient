using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Baggins.Models
{
    class UARelation
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "discountid")]
        public string DiscountId { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public int Flag { get; set; }

        public UARelation()
        {

        }

        public UARelation(String username, string discountid, int flag)
        {
            Username = username;
            DiscountId = discountid;
            Flag = flag;// liked = 1, disliked = -1, neutral = 0;
        }
    }
}
