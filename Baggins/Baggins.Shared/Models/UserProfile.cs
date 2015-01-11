using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Baggins.Models
{
    class UserProfile
    {
        public int id { get; set; }

        public int UId { get; set; }

        //Outlook login generated userid
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        public UserProfile()
        {

        }

        public UserProfile(String username, String firstname, String lastname, int score)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Score = score;
        }

    }
}
