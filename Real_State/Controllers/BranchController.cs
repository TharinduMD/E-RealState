﻿using Real_State.Models;
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

        public ActionResult Edit(String id)
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(String id, Branch updatedBranch)
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            branch.Street = updatedBranch.Street;
            branch.City = updatedBranch.City;
            branch.PostCode = updatedBranch.PostCode;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteBranch(String id)
        {
            Branch branch = context.Branchs.SingleOrDefault(x => x.BranchNo == id);
            context.Branchs.Remove(branch);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BranchFilter()
        {
            List<Branch> branch = context.Branchs.ToList();
            return View(branch);
        }

        public ActionResult Filter(String id)
        {
            var filter = context.Rents.Where(x => x.BranchNoRef == id).ToList().Count;
            ViewBag.branch = id;
            ViewBag.count = filter;
            return View();
        }
    }
}