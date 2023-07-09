using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.Models
{
    //creating table for product

    public class Admin
    {
        [Key]
        public int Admin_id { get; set; }
        [Required]

        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual User Username_id { get; set; }
        public string Admin_name { get; set; }
        public string Admin_mailid { get; set; }
        public string Admin_password { get; set; }
        public string Add_medicine { get; set; }

    }
}
