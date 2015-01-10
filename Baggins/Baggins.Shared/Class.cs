using System;
using System.Collections.Generic;
using System.Text;

namespace Baggins
{
    class Advertisement
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public string Details { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public Advertisement()
        {

        }

        public Advertisement(String title, String description, String source_name, String source_details, String link, String image, int likes, int dislikes)
        {
            Title = title;
            Description = description;
            SourceName = source_name;
            SourceDescription = source_details;
            Likes = likes;
            Dislikes = dislikes;
            Link = link;
            ImageLink = image;
            Details = likes + "";
        }
    }
}


