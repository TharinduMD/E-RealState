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
    }
}