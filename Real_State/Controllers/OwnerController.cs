using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        private Real_StateContext context = new Real_StateContext();
        public ActionResult Index()
        {
            List<Owner> AllOwners = context.Owners.ToList();
            return View(AllOwners);
        }
        public ActionResult Create()
        {    
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            context.Owners.Add(owner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Owner owner = context.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult Edit(String id)
        {
            Owner owner = context.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(String id, Owner updatedOwner)
        {
            Owner owner = context.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.FName = updatedOwner.FName;
            owner.LName = updatedOwner.LName;
            owner.Address = updatedOwner.Address;
            owner.TelNo = updatedOwner.TelNo;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Owner owner = context.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOwner(String id)
        {
            Owner owner = context.Owners.SingleOrDefault(x => x.OwnerNo == id);
            context.Owners.Remove(owner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}