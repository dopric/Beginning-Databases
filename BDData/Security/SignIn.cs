using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDData.Security
{
    public class SignIn
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
