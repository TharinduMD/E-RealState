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
            List<Staff> staff = context.Staffs.ToList();
            return View(staff);
        }

        public ActionResult Action()
        {
            return View();
        }
    }
}