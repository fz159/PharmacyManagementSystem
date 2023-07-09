using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.Models
{
    //creating table for product

    public class User
    {
        [Key]

        public int User_id { get; set; }
        [Required]
        public string User_name { get; set; }
        public string User_mailid { get; set; }
        public string User_password { get; set; }
    }
}
