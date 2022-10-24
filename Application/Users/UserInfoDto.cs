using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Details;
using Domain;

namespace Application.Users
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public ICollection<InfoDto> Info { get; set; } = new List<InfoDto>();
    }
}