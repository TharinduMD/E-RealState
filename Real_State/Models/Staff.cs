 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Real_State.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Staff Number")]
        public string StaffNo { get; set; }

        [Display(Name ="First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public string Position { get; set; }

        [Column(TypeName ="date")]
        [Display(Name = "Dath of Birth")]
        public DateTime DOB { get; set; }
        public int Salary { get; set; }

        [ForeignKey("Branch")]
        [Display(Name ="Branch")]
        public string Branch_BranchNoRef { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual List<Rent> Rent { get; set; }
    }
}