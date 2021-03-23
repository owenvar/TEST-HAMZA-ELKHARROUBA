using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Data
{
    public interface ICommentaireRepo
    {
        IEnumerable<Commentaire> GetAllComment();
        Commentaire GetCommentById(int id);
        Commentaire CreateComment(Commentaire commentaire);
        void DeleteComment(Commentaire commentaire);
        void EditComment(Commentaire commentaire);
        Commentaire GetLastComment();
        bool SaveChanges();
    }
}
