using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Application.Services.Courses;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Infrastructure.Persistence;

namespace StudentAdminPortal.Web.Pages.Courses
{
    public class DeleteModel : PageModel
    {

		/// <summary>
		/// The courses service
		/// </summary>
		private readonly ICoursesService coursesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteModel"/> class.
		/// </summary>
		/// <param name="_coursesService">The courses service.</param>
		public DeleteModel(ICoursesService _coursesService)
		{
			coursesService = _coursesService;
		}

		/// <summary>
		/// Gets or sets the course.
		/// </summary>
		/// <value>
		/// The course.
		/// </value>

		[BindProperty]
        public Course Course { get; set; } = default!;

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

            var course = await coursesService.GetByIdAsync(id.Value);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await coursesService.GetByIdAsync(id.Value);
            if (course != null)
            {
                Course = course;
                await coursesService.RemoveAsync(course);
            }

            return RedirectToPage("./Index");
        }
    }
}
