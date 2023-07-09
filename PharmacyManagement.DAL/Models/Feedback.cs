using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.Models
{
    //creating table for supplier

    public class Feedback
    {
        [Key]
        [Required]
        public int Feedback_id { get; set; }
        [Required]

        public int Service_rating { get; set; }
        public string Feedbacks { get; set; }

    }
}
