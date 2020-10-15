using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_State.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Owner Number")]
        public string OwnerNo { get; set; }
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Telephone Number")]
        public string TelNo { get; set; }

        public virtual List<Rent> Rent { get; set; }
    }
}
