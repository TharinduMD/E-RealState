using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        private Real_StateContext context = new Real_StateContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            context.Branchs.Add(branch);
            context.SaveChanges();
            return View();
        }
    }
}