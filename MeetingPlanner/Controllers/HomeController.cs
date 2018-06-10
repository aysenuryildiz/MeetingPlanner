using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetingPlanner.Models;
using System.Net;

namespace MeetingPlanner.Controllers
{
    public class HomeController : Controller
    {

        MeetingPlannerEntities db = new MeetingPlannerEntities();
      
        public ActionResult CreateMeeting()
        {
            return View();

        }
        public ActionResult Create(Meeting model)
        {
            try
            {
                model.Confirmation_ID = 1;
                db.Meeting.Add(model);
                db.SaveChanges();
                return RedirectToAction("ShowMeeting");
            }
            catch (Exception)
            {
               
                throw;
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting toplanti = db.Meeting.Find(id);
            if (toplanti == null)
            {
                return HttpNotFound();
            }
            return View(toplanti);
        }

        public ActionResult Accept(int? id)
        {
            try
            {

                var model = db.Meeting.Where(x => x.ID == id).FirstOrDefault();
                model.Confirmation_ID = 2;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowMeeting");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public ActionResult Declined(int? id)
        {
            try
            {

                var model = db.Meeting.Where(x => x.ID == id).FirstOrDefault();
                model.Confirmation_ID = 3;
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowMeeting");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting toplanti = db.Meeting.Find(id);
            db.Meeting.Remove(toplanti);
            db.SaveChanges();
            return RedirectToAction("ShowMeeting");
        }

        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            Meeting toplanti = db.Meeting.Find(id);
            if (toplanti == null)
            {
                return HttpNotFound();
            }
            db.Meeting.Remove(toplanti);
            db.SaveChanges();
            return RedirectToAction("ShowMeeting");
        }

        [AllowAnonymous]
        public ActionResult ShowMeeting()
        {

            return View();

        }

        public JsonResult ChangeUser(Room model)
        {
            var dene = db.Room.Where(x => x.ID == model.ID).FirstOrDefault();
            dene.Name = model.Name;
            dene.Capacity = model.Capacity;

            db.Entry(dene).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }

}
 
