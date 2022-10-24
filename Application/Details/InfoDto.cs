using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain;

namespace Application.Details
{
    public class InfoDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string FkAppUser { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }
}