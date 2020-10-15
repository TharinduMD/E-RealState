﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Real_State.Models
{
    public class Real_StateContext:DbContext
    {
        public DbSet<Owner> Owners{ get; set; }
        public DbSet<Rent> Rents{ get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Branch> Branchs { get; set; }
    }
}