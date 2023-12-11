using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoSurvey.Models
{
    public class User
    {
        public string? Name { get; set; }
        public string? Locations { get; set; }
        public string? Languages { get; set; }
        public string? Comments { get; set; } 
    }
}