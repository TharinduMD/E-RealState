using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Real_State.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private Real_StateContext context = new Real_StateContext();
        public ActionResult Index()
        {

            List<Staff> Allstaffs = context.Staffs.ToList();

            List<Staff> distictPosition = context.Staffs.GroupBy(x => x.Position).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Position = new SelectList(distictPosition, "Position", "Position");

            return View(Allstaffs);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<Staff> distictPosition = context.Staffs.GroupBy(x => x.Position).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Position = new SelectList(distictPosition, "Position", "Position");

            String pos = form["PosDropDown"]?.ToString();

            if (pos == null)
            {
                List<Staff> filterStaff = context.Staffs.ToList();
                return View(filterStaff);
            }
            else
            {
                List<Staff> filterStaff = context.Staffs.Where(x => x.Position == pos).ToList();
                return View(filterStaff);
            }
        }

        public ActionResult Create()
        {
            ViewBag.BranchDetails = context.Branchs;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.BranchDetails = context.Branchs;
            context.Staffs.Add(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.EditBranch = new SelectList(context.Branchs, "BranchNo", "Street");
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(String id,Staff updatedStaff)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.FName = updatedStaff.FName;
            staff.LName = updatedStaff.LName;
            staff.Position = updatedStaff.Position;
            staff.DOB = updatedStaff.DOB;
            staff.Salary = updatedStaff.Salary;
            staff.Branch_BranchNoRef = updatedStaff.Branch_BranchNoRef;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.StaffNo == id);
            context.Staffs.Remove(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}