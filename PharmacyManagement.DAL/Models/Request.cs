using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.Models
{ 
    //creating table for sale

    public class Request
    {
        [Key]
        [Required]
        public int Request_id { get; set; }
  
        public string Medicine_name { get; set; }
        public string Medicine_type { get; set; }
        public int  Quantity { get; set; }

        



    }
}
