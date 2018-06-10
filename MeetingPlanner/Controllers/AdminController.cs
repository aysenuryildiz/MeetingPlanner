using System.Linq;
using System.Web.Mvc;
using MeetingPlanner.Models;
using System;
using System.Net;
using System.Data;

namespace MeetingPlanner.Controllers
{
    public class AdminController : Controller
    {
        MeetingPlannerEntities db = new MeetingPlannerEntities();
      
        public ActionResult AddRoom()
        {
            
            return View();

        }

        public ActionResult CreateRoom(Room model)
        {
            try
            {
                db.Room.Add(model);
                db.SaveChanges();
                return RedirectToAction("AddRoom");

            }
            
            catch(Exception )
            {
                return View();
            }

        }
        
        public ActionResult UserSettings()
        {
            return View();

        }

       

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("DeleteRoom")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room salon = db.Room.Find(id);
            db.Room.Remove(salon);
            db.SaveChanges();
            return RedirectToAction("AddRoom");
        }
        public ActionResult DeleteRoom(FormCollection fcNotUsed, int id = 0)
        {

            Meeting toplanti = db.Meeting.Where(x => x.Room_ID == id).FirstOrDefault();

                Room salon = db.Room.Find(id);
                if (salon == null || toplanti!=null )
                {
               
                return RedirectToAction("AddRoom");


                 }
                db.Room.Remove(salon);
                db.SaveChanges();
                return RedirectToAction("AddRoom");
           
           

            }

        public ActionResult Edit(int id = 0)
        {
            Room salon = db.Room.Find(id);
            if (salon == null)
            {
                return HttpNotFound();

            }
            return View(salon);




        }
        [HttpPost]
        public ActionResult Edit(Room salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("AddRoom");

            }
            return View(salon);
        }


    }

    }
