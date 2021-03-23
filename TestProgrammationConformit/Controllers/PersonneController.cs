using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Data;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Controllers
{

    [Route("conformit/api/v1/personnes")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneRepo _repository;

        public PersonneController(IPersonneRepo repository) 
        {
            _repository = repository;
        }
        /************ Get all persones ************/
        // GET conformit/api/v1/personnes
        [HttpGet]
        public ActionResult<IEnumerable<Personne>> GetAllPersone()
        {
            var PersoneItem = _repository.GetAllPersone();
            return Ok(PersoneItem);
        }

        /************ Get persone by id ************/
        // GET conformit/api/v1/personnes/{id}  
        [HttpGet("{id}")]
        public ActionResult<Personne> getPersone(int id)
        {
            var personItem = _repository.GetPersoneById(id);
            if (personItem != null)
            {
                return Ok(personItem);
            }
            else
            {
                return NotFound();
            }

        }

        /************ Create a new resource ************/
        // POST conformit/api/v1/personnes
        [HttpPost]
        public ActionResult<Personne> CreateNewPersone(Personne personne)
        {

            var lastpersone = _repository.GetLastPersone(); // Get Last record in db 
            if (lastpersone != null) // check if item is not null
            {
                personne.Id = lastpersone.Id + 1;
                _repository.CreatePersone(personne);
                _repository.SaveChanges();
                return Ok(personne);
            }
            else
            {
                personne.Id = 1;
                _repository.CreatePersone(personne);
                _repository.SaveChanges();
                return Ok(personne);
            }
        }
    }
}
