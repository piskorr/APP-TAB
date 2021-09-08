using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TabApp.Models
{
    public class LoginCredentials
    {
        [ForeignKey("Person")]
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 6)]
        [Required]
        public String UserName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 6)]
        [Required]
        public String Password { get; set; }

        
        public virtual Person Person { get; set; }
    }
}
