using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;

namespace PharmacyManagement.DAL.Models
{
    public class Medicine
    {
        //creating table for purchase

        [Key]
        public int Medicine_id { get; set; }

        

        // till above is syntax for FK

        public string Medicine_name { get; set; }
        public string Medicine_type { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
