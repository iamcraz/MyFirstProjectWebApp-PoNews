using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirsyProjectWebApp.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepositroy pageRepository;
        MyFirstWebAppContext db = new MyFirstWebAppContext();

        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}