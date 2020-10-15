using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_State.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Property Number")]
        public string PropertyNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        [Display(Name ="Property Type")]
        public string Ptype { get; set; }
        public int Rooms { get; set; }

        [ForeignKey("Owner")]
        [Display(Name ="Owner")]
        public string OwnerNoRef { get; set; }

        [ForeignKey("Staff")]
        [Display(Name ="Staff")]
        public String StaffNoRef { get; set; }

        [ForeignKey("Branch")]
        [Display(Name ="Branch")]
        public string BranchNoRef { get; set; }

        [Display(Name ="Rent Amount")]
        public int Rent1 { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Owner Owner { get; set; }

    }
}