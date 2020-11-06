using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.project.Models
{
    public class Designation
    {
        [Key]
        public int Desg_ID { get; set; }

        [Required(ErrorMessage = "Emloyee {0} is required")]
        [DataType(DataType.Text)]
        public string Desg_Name { get; set; }

    }
}
