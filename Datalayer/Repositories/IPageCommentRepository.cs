using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetAllcomments(int id);
        PageComment GetCommentByID(int CommentID);
        bool Insert(PageComment Comment);
        bool Uptade(PageComment Comment);
        bool Delete(PageComment Comment);
        bool Delete(int CommentID);
        void save();
        void dispose();
    }
}
