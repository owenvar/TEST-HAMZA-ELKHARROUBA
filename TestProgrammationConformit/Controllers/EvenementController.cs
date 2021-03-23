using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Data;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Controllers
{
    [Route("conformit/api/v1/events")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private IEvenementRepo _repository;

        public EvenementController(IEvenementRepo repo)
        {
            _repository = repo;
        }

        /************ Get all Event ************/
        // GET conformit/api/v1/events
        [HttpGet]
        public ActionResult<IEnumerable<Evenement>> GetAllEvent(int? page = null, int? pageSize = null)
        {
           
            var EventItems = _repository.GetAllEvent().AsQueryable();
            if( page != null) 
            {
                EventItems = EventItems.Skip((int)((page - 1) * pageSize));
            }
            if (pageSize != null)
            {
                EventItems = EventItems.Take((int)pageSize);
            }
            return Ok(EventItems.ToList());
        }

        /************ Get Event by id ************/
        // Get conformit/api/v1/events/{id}  
        [HttpGet("{id}")]
        
        public ActionResult<Evenement> getEvent(int id)
        {
            var EventItem = _repository.GetEventById(id);
            if (EventItem != null)
            {
                return Ok(EventItem);
            }
            else
            {
                return NotFound();
            }

        }

        /************ Create a new resource ************/
        // POST conformit/api/v1/events
        [HttpPost]
        
        public ActionResult<Evenement> CreateNewEvent( Evenement evenement) 
        {
         
            var lastEvent = _repository.GetLastEvent(); // Get Last record in db 
            if (lastEvent != null) // check if item is not null
            {
                evenement.IdEvent = lastEvent.IdEvent + 1; 
                _repository.CreateEvent(evenement);
                _repository.SaveChanges();
                return Ok(evenement);
            }
            else 
            {
                evenement.IdEvent = 1;
                _repository.CreateEvent(evenement);
                _repository.SaveChanges();
                return Ok(evenement);
            }
        }

        /******** Method for  test if I'm getting last record **********/
        //  GET conformit/api/v1/events/last
        [HttpGet("last")]
        public ActionResult<Evenement> GetLastEvent() 
        {
           return Ok( _repository.GetLastEvent());
        }


        /************ Method for Delete an event By id **************/
        // DELETE conformit/api/v1/events/{id}
        [HttpDelete("{id}")]
        public ActionResult<Evenement> DeleteEvent(int id) 
        {
            var EventItem = _repository.GetEventById(id);
            if(EventItem != null) 
            {
                _repository.DeleteEvent(EventItem);
                _repository.SaveChanges();
                return Ok($"Event Id : {id}  deleted successfully !");
            }
            else 
            {
                return NotFound();
            }    
        }

        /************* Method for Update an event by id ***********/
        // PATCH conformit/api/v1/events/{id}
        [HttpPatch("{id}")]
        public ActionResult<Evenement> UpdateEvent(int id,Evenement evenement)
        {
            var EventItem = _repository.GetEventById(id);
            if (EventItem != null)
            {
                 if( evenement.Titre != null) 
                 {
                    EventItem.Titre = evenement.Titre;
                 }
                 if (evenement.Description != null)
                 {
                    EventItem.Description = evenement.Description;
                 }

                 _repository.EditEvent(EventItem);
                 _repository.SaveChanges();
                 return Ok($"Event Id : {id}  Updated successfully !");
            }
            else
            {
                return NotFound();
            }

        }

    }
}
