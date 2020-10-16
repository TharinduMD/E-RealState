using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private Real_StateContext context = new Real_StateContext();
        public ActionResult Index()
        {
            List<Staff> AllStaffs = context.Staffs.ToList();
            return View(AllStaffs);
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
            return View();
        }
    }
}