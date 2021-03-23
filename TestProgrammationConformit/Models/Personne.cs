using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Models
{
    public class Personne
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }   
        public string Email { get; set; }
    }
}
