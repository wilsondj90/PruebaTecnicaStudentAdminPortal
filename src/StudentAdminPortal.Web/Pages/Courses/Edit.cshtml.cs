using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Application.Services.Courses;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.Courses
{
	public class EditModel : PageModel
    {
		/// <summary>
		/// The courses service
		/// </summary>
		private readonly ICoursesService coursesService;

        public EditModel(ICoursesService _coursesService)
        {
            coursesService = _coursesService;
        }

		/// <summary>
		/// Gets or sets the course.
		/// </summary>
		/// <value>
		/// The course.
		[BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =  await coursesService.GetByIdAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await coursesService.UpdateAsync(course: Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

		/// <summary>
		/// Courses the exists.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		private bool CourseExists(int id)
        {
            return coursesService.Any(id);
        }
    }
}
