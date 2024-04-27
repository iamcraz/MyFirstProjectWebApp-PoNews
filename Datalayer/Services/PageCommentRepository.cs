using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datalayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private MyFirstWebAppContext db;
        public PageCommentRepository(MyFirstWebAppContext context)
        {
            this.db = context;
        }
        public bool Delete(PageComment Comment)
        {
            try
            {
                db.Entry(Comment).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int CommentID)
        {
            try
            {
                var user = GetCommentByID(CommentID);

                Delete(user);

                return true;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<PageComment> GetAllcomments(int id)
        {
            return db.PageComments.Where(x=>x.PageID==id);
        }

        public PageComment GetCommentByID(int CommentID)
        {
            return db.PageComments.Find(CommentID);
        }

        public bool Insert(PageComment Comment)
        {
            try
            {
                db.PageComments.Add(Comment);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }

        public bool Uptade(PageComment Comment)
        {
            try
            {
                db.Entry(Comment).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void dispose()
        {
            db.Dispose();
        }

        
    }
}
