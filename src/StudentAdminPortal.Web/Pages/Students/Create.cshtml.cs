using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        /// <summary>
        /// The students service
        /// </summary>
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="_studentService">The student service.</param>
        public CreateModel(IStudentsService _studentService)
        {
            studentsService = _studentService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await this.studentsService.AddAsync(Student);
            return RedirectToPage("./Index");
        }
    }
}
