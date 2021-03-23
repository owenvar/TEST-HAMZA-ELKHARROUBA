using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Data;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Controllers
{
    [Route("conformit/api/v1/comments")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private ICommentaireRepo _repository;

        public CommentaireController(ICommentaireRepo repo)
        {
            _repository = repo;
        }

        /************ Get all Comment ************/
        // GET conformit/api/v1/comments
        [HttpGet]
        public ActionResult<IEnumerable<Commentaire>> GetAllComment()
        {
            var commentItem = _repository.GetAllComment();
            return Ok(commentItem);
        }

        /************ Get Comment by id ************/
        // GET conformit/api/v1/comments/{id}  - 
        [HttpGet("{id}")]
        public ActionResult<Commentaire> getComment(int id)
        {
            var commentItem = _repository.GetCommentById(id);
            if (commentItem != null)
            {
                return Ok(commentItem);
            }
            else
            {
                return NotFound();
            }

        }

        /************ Create a new comment ************/
        // POST conformit/api/v1/comments
        [HttpPost]
        public ActionResult<Commentaire> CreateNewComment(Commentaire commentaire)
        {

            var lastComment = _repository.GetLastComment(); // Get Last record in db 
            if (lastComment != null) // check if item is not null
            {
                commentaire.Id = lastComment.Id + 1;
                _repository.CreateComment(commentaire);
                _repository.SaveChanges();
                return Ok(commentaire);
            }
            else
            {
                commentaire.Id = 1;
                _repository.CreateComment(commentaire);
                _repository.SaveChanges();
                return Ok(commentaire);
            }
        }


        /************ Method for Delete comment By id **************/
        // DELETE conformit/api/v1/comments/{id}
        [HttpDelete("{id}")]
        public ActionResult<Commentaire> DeleteComment(int id)
        {
            var commentItem = _repository.GetCommentById(id);
            if (commentItem != null)
            {
                _repository.DeleteComment(commentItem);
                _repository.SaveChanges();
                return Ok($"Comment Id : {id}  deleted successfully !");
            }
            else
            {
                return NotFound();
            }
        }

        /************* Method for Update comment by id ***********/
        // PATCH conformit/api/v1/comments/{id}
        [HttpPatch("{id}")]
        public ActionResult<Commentaire> UpdateComment(int id, Commentaire commentaire)
        {
            var commentItem = _repository.GetCommentById(id);
            if (commentItem != null)
            {
                if (commentaire.Contenu != null)
                {
                    commentItem.Contenu = commentaire.Contenu;
                }

                _repository.EditComment(commentItem);
                _repository.SaveChanges();
                return Ok($"Comment Id : {id}  Updated successfully !");
            }
            else
            {
                return NotFound();
            }

        }

    }
}

