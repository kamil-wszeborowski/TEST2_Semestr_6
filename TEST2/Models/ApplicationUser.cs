using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() {  }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Pesel { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
