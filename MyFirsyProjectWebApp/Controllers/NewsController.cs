using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer;

namespace MyFirsyProjectWebApp.Controllers
{
    public class NewsController : Controller
    {
        private IPageGroupRepository pageGroupRepository;
        private IPageRepositroy pageRepositroy;
        private IPageCommentRepository pageCommentRepository;

        MyFirstWebAppContext db = new MyFirstWebAppContext();
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepositroy = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }
        // GET: News
        public ActionResult ShowGroups()
        {
           
            return PartialView(pageGroupRepository.showGroupsforView());
        }

        public ActionResult ShowGroupsNavBar()
        {
            return PartialView(pageGroupRepository.showGroupsforView());
        }
        public ActionResult ShowLatestNewsByView()
        {
            
            return PartialView(pageRepositroy.GetPagesByView(4));
        }
        public ActionResult ShowSlider()
        {
            return PartialView(pageRepositroy.GetPagesBySlider());
        }
        public ActionResult ShowLatestNewsByDate()
        {
            return PartialView(pageRepositroy.GetPagesByDate(3));
        }
        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepositroy.GetPageByID(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            news.Visit += 1;
            pageRepositroy.Uptade(news);
            pageRepositroy.save();
            return View(news);
        }
        [Route("GroupsNews/{id}")]
        public ActionResult ShowGroupsNews(int id)
        {
            var title = pageRepositroy.GetPagesTitleByGroupId(id);
            ViewBag.TitleName = title;
            return View(pageRepositroy.GetPagesByGroupID(id));
        }
        public ActionResult ShowComments(int id)
        {
            
            return PartialView(pageCommentRepository.GetAllcomments(id));
        }
        public ActionResult Add_Comment(int id, string name, string email, string comment)
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                Name = name,
                Email=email,
                Comment=comment,
                PageID=id
            };

            pageCommentRepository.Insert(addcomment);
            pageCommentRepository.save();

            return null;
        }
        public ActionResult Show_AddComment(int id)
        {
            var news = pageRepositroy.GetPageByID(id);

            return PartialView(news);
        }
    }
}