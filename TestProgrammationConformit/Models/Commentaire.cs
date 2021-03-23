using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Models
{
    public class Commentaire
    {
        [Key]
        public  int Id { set; get; }

        [ForeignKey("Evenement")]
        public int IdEvent { get; set; }
        
        [Required]
        public string Contenu { set; get; }
        
        [JsonIgnore]
        public Evenement Evenement { get; set; }
    }
}
