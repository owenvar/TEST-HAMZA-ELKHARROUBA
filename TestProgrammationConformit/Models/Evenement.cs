using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Models
{
    public class Evenement
    {
        [Key]
        public int IdEvent { get; set; }
        [Required]
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Personne { get; set; }

        [JsonIgnore]
        public ICollection<Commentaire> Commentaires { get; set; }
     
    }
}
