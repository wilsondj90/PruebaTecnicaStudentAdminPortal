using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="_studentsService">The students service.</param>
        public IndexModel(IStudentsService _studentsService)
        {
            studentsService = _studentsService;
        }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public IList<Student> Student { get; set; } = default!;

        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        public async Task OnGetAsync()
        {
            Student = await studentsService.GetAllAsync();
        }
    }
}
