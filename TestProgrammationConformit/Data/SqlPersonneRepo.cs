using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public class SqlPersonneRepo : IPersonneRepo
    {
        private readonly ConformitContext _context;

        public SqlPersonneRepo(ConformitContext context)
        {
            _context = context;
        }

        // Create New Person 
        public Personne CreatePersone(Personne personne)
        {
            //throw new NotImplementedException();
            if (personne == null)
            {
                throw new ArgumentNullException(nameof(Personne));
            }

            _context.Personne.Add(personne);

            return personne;
        }

        // Get all ersone
        public IEnumerable<Personne> GetAllPersone()
        {
            //throw new NotImplementedException();
            return _context.Personne.ToList();
        }

        // Get Last record 
        public Personne GetLastPersone()
        {
            //throw new NotImplementedException();
            try
            {
                var LastId = _context.Personne.Max(o => o.Id);
                return _context.Personne.FirstOrDefault(o => o.Id == LastId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        // GET persone by id
        public Personne GetPersoneById(int id)
        {
            //throw new NotImplementedException();
            return _context.Personne.FirstOrDefault(o => o.Id == id);
        }

        // save changes in db
        public bool SaveChanges()
        {
            //throw new NotImplementedException();
            return (_context.SaveChanges() >= 0);
        }
    }
}
