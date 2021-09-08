using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TabApp.Models
{
    public class LoginCredentials
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 6)]
        [Required]
        public String UserName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 6)]
        [Required]
        public String Password { get; set; }

        //[Required]asdas
        //public virtual Person Person { get; set; }
    }
}
