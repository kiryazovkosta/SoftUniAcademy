using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Key]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
