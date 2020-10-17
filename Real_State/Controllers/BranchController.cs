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
            List<Branch> AllBranch = context.Branchs.ToList();
            return View(AllBranch);
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
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id)
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        public ActionResult Edit()
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
    }
}