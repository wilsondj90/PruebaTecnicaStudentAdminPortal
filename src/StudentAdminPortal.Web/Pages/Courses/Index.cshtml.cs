using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.Courses;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.Courses
{
	public class IndexModel : PageModel
    {
		private readonly ICoursesService coursesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="IndexModel"/> class.
		/// </summary>
		/// <param name="_coursesService">The courses service.</param>
		public IndexModel(ICoursesService _coursesService)
		{
			coursesService = _coursesService;
		}

		/// <summary>
		/// Gets or sets the course.
		/// </summary>
		/// <value>
		/// The course.
		/// </value>
		public IList<Course> Course { get; set; } = default!;

		/// <summary>
		/// Called when [get asynchronous].
		/// </summary>
		public async Task OnGetAsync()
		{
			Course = await coursesService.GetAllAsync();
		}
	}
}
