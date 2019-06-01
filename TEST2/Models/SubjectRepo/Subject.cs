using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEST2.Models.SubjectRepo
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Subjectname cannot exceed 50 characters")]
        public string SubjectName { get; set; }
        [Required]
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }
    }
}
