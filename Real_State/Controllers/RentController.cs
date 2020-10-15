﻿using Real_State.Models;
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
            return View();
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
            return View();
        }
    }
}