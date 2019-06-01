using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TEST2.Models;

namespace TEST2.ViewModels
{
    public class SubjectCreateViewModel
    {
        
        [Required]
        [MaxLength(50, ErrorMessage = "Subjectname cannot exceed 50 characters")]
        public string SubjectName { get; set; }
        [Required]
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }
    }
}
