using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Application.Services.Courses;

namespace StudentAdminPortal.Web.Pages.Courses
{
	public class CreateModel : PageModel
    {

		/// <summary>
		/// The course service
		/// </summary>
		private readonly ICoursesService courseServices;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateModel"/> class.
		/// </summary>
		/// <param name="_courseService">The course service.</param>
		public CreateModel(ICoursesService _coursesService)
		{
			courseServices = _coursesService;
		}

		public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await this.courseServices.AddAsync(Course);
			return RedirectToPage("./Index");
		}
	}
}

