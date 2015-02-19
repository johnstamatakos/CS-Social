using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSProject.Models;

namespace SSProject.Controllers
{
    public class FriendsController : Controller
    {
        private SSPEntity db = new SSPEntity();

        // GET: Friends
        public ActionResult Index()
        {
            return View(db.UserRelationships.ToList());
        }

        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRelationship userRelationship = db.UserRelationships.Find(id);
            if (userRelationship == null)
            {
                return HttpNotFound();
            }
            return View(userRelationship);
        }

        // GET: Friends/Create
        //Issue with friendID being null
        //set status to request/pending for validation
        public ActionResult Create(string friendId)
        {
            var userId = User.Identity.GetUserId();
            db.UserRelationships.Add(new UserRelationship { UserId = userId, FriendId = friendId, Status = "Accepted", AcceptedDate = DateTime.Now});
            db.UserRelationships.Add(new UserRelationship { UserId = friendId, FriendId = userId, Status = "Accepted", AcceptedDate = DateTime.Now });
            db.SaveChanges();
            return RedirectToAction("Details", "Profile", new { id = User.Identity.GetUserId() });
        }

        //// POST: Friends/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FriendId,Status,AcceptedDate,RelationshipId")] UserRelationship userRelationship)
        {
            if (ModelState.IsValid)
            {
                db.UserRelationships.Add(userRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRelationship);
        }



        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRelationship userRelationship = db.UserRelationships.Find(id);
            if (userRelationship == null)
            {
                return HttpNotFound();
            }
            return View(userRelationship);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FriendId,Status,AcceptedDate,RelationshipId")] UserRelationship userRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRelationship);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRelationship userRelationship = db.UserRelationships.Find(id);
            if (userRelationship == null)
            {
                return HttpNotFound();
            }
            return View(userRelationship);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRelationship userRelationship = db.UserRelationships.Find(id);
            db.UserRelationships.Remove(userRelationship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
