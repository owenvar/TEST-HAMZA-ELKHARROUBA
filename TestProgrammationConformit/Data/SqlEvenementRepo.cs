using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public class SqlEvenementRepo : IEvenementRepo
    {
        private readonly ConformitContext _context;

        public SqlEvenementRepo(ConformitContext context) 
        {
            _context = context;
        }


        // Create Event 
        public Evenement CreateEvent(Evenement evenement)
        {
            if(evenement == null) 
            {
                throw new ArgumentNullException(nameof(evenement));
            }

            _context.Evenement.Add(evenement);
            
            return evenement;
        }


        // Delete Event
        public void DeleteEvent(Evenement evenement)
        {
            //throw new NotImplementedException();
            _context.Evenement.Remove(evenement);
        }


        // Update Event
        public void EditEvent(Evenement evenement)
        {
            //throw new NotImplementedException();
            _context.Evenement.Update(evenement);
        }

        // Get All Event 
        public IEnumerable<Evenement> GetAllEvent()
        {
            //throw new NotImplementedException();

            //return _context.Evenement.ToList();
            return _context.Evenement;
        }

        // Get a event by id
        public Evenement GetEventById(int id)
        {
            //throw new NotImplementedException();

            return _context.Evenement.FirstOrDefault( o => o.IdEvent == id);
        }

        // Get Last Event 
        public Evenement GetLastEvent()
        {
            try { 
                var LastId = _context.Evenement.Max(o => o.IdEvent);
                return _context.Evenement.FirstOrDefault(o => o.IdEvent == LastId);
            }
            catch(Exception e) {
                return null;
            }
        }
        
        // Save Chanages in DB
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0 );
        }
    }
}
