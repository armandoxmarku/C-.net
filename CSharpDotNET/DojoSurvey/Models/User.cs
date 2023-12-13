using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace DojoSurvey.Models
{
    public class User
    {
        [Required(ErrorMessage ="emri duhet te plotesohet")]
        [MinLength(4 , ErrorMessage ="gjatesia me e madhe se 3 shkronja")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Locationi duhet te plotesohet")]
        [MinLength(2, ErrorMessage ="gjatesia me e madhe se 1 shkronj")]
        public string Locations { get; set; }
        [Required(ErrorMessage ="gjuha preferuar duhet te plotesohet")]
        public string Languages { get; set; }
         [Required(ErrorMessage ="gjuha preferuar duhet te plotesohet")]
        [MinLength(20 , ErrorMessage ="gjatesia me e madhe se 20 shkronja")]
        public string Comments { get; set; } 
    }
}