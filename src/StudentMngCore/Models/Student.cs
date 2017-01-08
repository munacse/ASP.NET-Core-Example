
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMngCore.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(15)]
        public string ConNumber { get; set; }

        [StringLength(50)]
        [Required]
        public string Roll { get; set; }

        public int Age { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
