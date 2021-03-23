using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public interface IEvenementRepo
    {
        IEnumerable<Evenement> GetAllEvent();
        Evenement GetEventById(int id);
        Evenement CreateEvent(Evenement evenement);
        void DeleteEvent(Evenement evenement);
        void EditEvent(Evenement evenement);
        Evenement GetLastEvent();
        bool SaveChanges();
    }
}
