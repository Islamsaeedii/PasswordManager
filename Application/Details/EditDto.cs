using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Details
{
    public class EditDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}