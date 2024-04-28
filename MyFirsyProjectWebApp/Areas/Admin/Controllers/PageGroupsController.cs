using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datalayer;

namespace MyFirsyProjectWebApp.Areas.Admin.Controllers
{
    
    public class PageGroupsController : Controller
    {
        private IPageGroupRepository pageGroupRepository;

        // GET: Admin/PageGroups
        MyFirstWebAppContext db = new MyFirstWebAppContext();
        public PageGroupsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            
        }
        [Authorize]
        public  ActionResult Index()
        {
            return View(pageGroupRepository.GetAllGroups());
        }
        [Authorize]
        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupByID(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }
        [Authorize]
        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.Insert(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupByID(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.Uptade_group(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupByID(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            pageGroupRepository.Delete(id);
            pageGroupRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
