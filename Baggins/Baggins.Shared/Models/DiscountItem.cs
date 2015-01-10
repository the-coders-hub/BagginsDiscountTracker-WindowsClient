using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Baggins.Models
{
    class DiscountItem
    {
        public string Id { get; set; }

        public string DiscountId { get; set; }

        public string UId { get; set; }

        [JsonProperty(PropertyName = "validupto")]
        public string ValidUpto { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "upvotes")]
        public string Upvotes { get; set; }

        [JsonProperty(PropertyName = "downvotes")]
        public string Downpvotes { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        public string CId { get; set; }

    }
}
