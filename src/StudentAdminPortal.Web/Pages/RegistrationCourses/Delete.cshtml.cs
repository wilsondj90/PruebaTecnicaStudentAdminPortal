using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdminPortal.Application.Services.RegistrationCourses;
using StudentAdminPortal.Domain.Entities;


namespace StudentAdminPortal.Web.Pages.RegistrationCourses
{
	public class DeleteModel : PageModel
	{
		/// <summary>
		/// The registrationCourses service
		/// </summary>
		private readonly IRegistrationCoursesService registrationCoursesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteModel"/> class.
		/// </summary>
		/// <param name="_registrationCoursesService">The registrationCourses service.</param>
		public DeleteModel(IRegistrationCoursesService _registrationCoursesService)
		{
			registrationCoursesService = _registrationCoursesService;
		}

		/// <summary>
		/// Gets or sets the registrationCourse.
		/// </summary>
		/// <value>
		/// The registrationCourse.
		/// </value>
		[BindProperty]
		public RegistrationCourse RegistrationCourse { get; set; } = default!;

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

			var registrationCourse = await registrationCoursesService.GetByIdAsync(id.Value);

			if (registrationCourse == null)
			{
				return NotFound();
			}
			else
			{
				RegistrationCourse = registrationCourse;
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

			var registrationCourse = await registrationCoursesService.GetByIdAsync(id.Value);
			if (registrationCourse != null)
			{
				RegistrationCourse = registrationCourse;
				await registrationCoursesService.RemoveAsync(registrationCourse);
			}

			return RedirectToPage("./Index");
		}
	}
}
