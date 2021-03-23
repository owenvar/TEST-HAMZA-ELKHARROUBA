using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public interface IPersonneRepo
    {
        IEnumerable<Personne> GetAllPersone();
        Personne GetPersoneById(int id);
        Personne CreatePersone(Personne personne);
        Personne GetLastPersone();
        bool SaveChanges();
    }
}
