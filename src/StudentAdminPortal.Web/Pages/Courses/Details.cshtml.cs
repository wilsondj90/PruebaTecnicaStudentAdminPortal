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
    public class DetailsModel : PageModel
    {
		/// <summary>
		/// The courses service
		/// </summary>
		private readonly ICoursesService coursesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="DetailsModel"/> class.
		/// </summary>
		/// <param name="_coursesService">The courses service.</param>
		public DetailsModel(ICoursesService _coursesService)
		{
			coursesService = _coursesService;
		}

		/// <summary>
		/// Gets or sets the course.
		/// </summary>
		/// <value>
		/// The course.
		/// </value>
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
    }
}
