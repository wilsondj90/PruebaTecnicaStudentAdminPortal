using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortal.Web.Pages.RegistrationCourses.ViewModels
{
    public class StudentRegistrationCourseInputDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
