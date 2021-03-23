using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public class SqlCommentaireRepo : ICommentaireRepo
    {

        private readonly ConformitContext _context;

        public SqlCommentaireRepo(ConformitContext context)
        {
            _context = context;
        }

        // create new comment 
        public Commentaire CreateComment(Commentaire commentaire)
        {
            //throw new NotImplementedException();
            if (commentaire == null)
            {
                throw new ArgumentNullException(nameof(commentaire));
            }

            _context.Commentaire.Add(commentaire);

            return commentaire;
        }

        // delete comment 
        public void DeleteComment(Commentaire commentaire)
        {
            //throw new NotImplementedException();
            _context.Commentaire.Remove(commentaire);
        }

        // update comment  by id 
        public void EditComment(Commentaire commentaire)
        {
            //throw new NotImplementedException();
            _context.Commentaire.Update(commentaire);
        }

        // get all comment 
        public IEnumerable<Commentaire> GetAllComment()
        {
            //throw new NotImplementedException();
            return _context.Commentaire.ToList();
        }

        // get comment by id 
        public Commentaire GetCommentById(int id)
        {
            //throw new NotImplementedException();
            return _context.Commentaire.FirstOrDefault(o => o.Id == id);
        }

        // get last record 
        public Commentaire GetLastComment()
        {
            //throw new NotImplementedException();
            try
            {
                var LastId = _context.Commentaire.Max(o => o.Id);
                return _context.Commentaire.FirstOrDefault(o => o.Id == LastId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // save changes in db 
        public bool SaveChanges()
        {
            //throw new NotImplementedException();
            try
            {
                return (_context.SaveChanges() >= 0);
            }
            catch(Exception e) 
            {
                return false;  
            }
            
           
        }
    }
}
