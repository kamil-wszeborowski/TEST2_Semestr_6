using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TEST2.Models.Validators;

namespace TEST2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() {  }

        [Required]
        [MaxLength(50,ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [Required]
        public long Pesel { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
