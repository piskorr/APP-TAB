using System;
using System.ComponentModel.DataAnnotations;

namespace TabApp.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Display(Name = "Serial number")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public String SerialNumber { get; set; }


        [StringLength(100, MinimumLength = 3)]
        [Required]
        public String Description { get; set; }
    }
}