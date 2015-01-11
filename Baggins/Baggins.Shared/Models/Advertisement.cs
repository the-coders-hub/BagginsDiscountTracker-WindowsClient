using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Baggins.Models
{
    class Advertisement
    {
        //Discount ID
        public string DiscountId { get; set; }

        //Title
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        //Description
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        //Username
        [JsonProperty(PropertyName = "username")]
        public string SourceName { get; set; }

        //Link
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        //Image
        [JsonProperty(PropertyName = "imagelink")]
        public string ImageLink { get; set; }

        //Likes
        public int Likes { get; set; }

        //Dislikes
        public int Dislikes { get; set; }

        //Company
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        //Category
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        //Active?
        public bool IsActive { get; set; }

        //Validity
        [JsonProperty(PropertyName = "validupto")]
        public DateTime ValidUpto { get; set; }

        public Advertisement()
        {

        }
        public Advertisement(String title, String description, String source_name, String link, String image, int likes, int dislikes, String company, String category, bool active, DateTime validupto)
        {
            Title = title;
            Description = description;
            SourceName = source_name;
            Likes = likes;
            Dislikes = dislikes;
            Link = link;
            ImageLink = image;
            Company = company;
            Category = category;
            IsActive = active;
            ValidUpto = validupto;
        }
    }
}


