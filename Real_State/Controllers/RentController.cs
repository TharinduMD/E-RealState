using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        private Real_StateContext context = new Real_StateContext();
        public ActionResult Index()
        {
            List<Rent> AllRents = context.Rents.ToList();

            List<Rent> distictProperty = context.Rents.GroupBy(x => x.City).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Property = new SelectList(distictProperty, "City", "City");

            return View(AllRents);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<Rent> AllRents = context.Rents.ToList();

            List<Rent> distictProperty = context.Rents.GroupBy(x => x.City).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Property = new SelectList(distictProperty, "City", "City");
            
            String property = form["PropDropDown"]?.ToString();

            if (property == null)
            {
                List<Rent> filterProperty = context.Rents.ToList();
                return View(filterProperty);
            }
            else
            {
                List<Rent> filterProperty = context.Rents.Where(x => x.City == property).ToList();
                return View(filterProperty);
            }
        }

        public ActionResult Create()
        {
            ViewBag.OwnerDetails = context.Owners;
            ViewBag.BranchDetails = context.Branchs;
            ViewBag.StaffDetails = context.Staffs;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            ViewBag.OwnerDetails = context.Owners;
            ViewBag.BranchDetails = context.Branchs;
            ViewBag.StaffDetails = context.Staffs;
            context.Rents.Add(rent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Rent rent = context.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Edit(String id)
        {
            Rent rent = context.Rents.SingleOrDefault(x => x.PropertyNo == id);

            ViewBag.EditOwner = new SelectList(context.Owners, "OwnerNo", "FName");
            ViewBag.EditStaff = new SelectList(context.Staffs, "StaffNo", "FName");
            ViewBag.EditBranch = new SelectList(context.Branchs, "BranchNo", "Street");
            return View(rent);
        }

        [HttpPost]
        public ActionResult Edit(String id,Rent UpdatedRent)
        {
            Rent rent = context.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.Street = UpdatedRent.Street;
            rent.City = UpdatedRent.City;
            rent.Ptype = UpdatedRent.Ptype;
            rent.Rooms = UpdatedRent.Rooms;
            rent.OwnerNoRef = UpdatedRent.OwnerNoRef;
            rent.StaffNoRef = UpdatedRent.StaffNoRef;
            rent.BranchNoRef = UpdatedRent.BranchNoRef;
            rent.Rent1 = UpdatedRent.Rent1;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Rent rent = context.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Rent rent = context.Rents.SingleOrDefault(x => x.PropertyNo == id);
            context.Rents.Remove(rent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}