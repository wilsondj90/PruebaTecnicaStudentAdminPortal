using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// The students service
        /// </summary>
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsModel"/> class.
        /// </summary>
        /// <param name="_studentsService">The students service.</param>
        public DetailsModel(IStudentsService _studentsService)
        {
            studentsService = _studentsService;
        }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        public Student Student { get; set; } = default!;


        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentsService.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
