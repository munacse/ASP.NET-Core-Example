
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMngCore.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int CourseId { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string Code { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
