using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.RegistrationCourses;
using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Web.Pages.RegistrationCourses
{
	public class IndexModel : PageModel
	{
		private readonly IRegistrationCoursesService registrationCoursesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="IndexModel"/> class.
		/// </summary>
		/// <param name="_registrationCoursesService">The registrationCourses service.</param>
		public IndexModel(IRegistrationCoursesService _registrationCoursesService)
		{
			registrationCoursesService = _registrationCoursesService;
		}

		/// <summary>
		/// Gets or sets the registrationCourse.
		/// </summary>
		/// <value>
		/// The registrationCourse.
		/// </value>
		public IList<RegistrationCourse> RegistrationCourse { get; set; } = default!;

		/// <summary>
		/// Called when [get asynchronous].
		/// </summary>
		public async Task OnGetAsync()
		{
			RegistrationCourse = await registrationCoursesService.GetAllAsync();
		}
	}
}

