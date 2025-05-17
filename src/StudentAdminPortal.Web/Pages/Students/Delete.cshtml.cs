using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Infrastructure.Persistence;

namespace StudentAdminPortal.Web.Pages.Students
{
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// The students service
        /// </summary>
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="_studentsService">The students service.</param>
        public DeleteModel(IStudentsService _studentsService)
        {
           studentsService = _studentsService;
        }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>
        /// The student.
        /// </value>
        [BindProperty]
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

            var student = await studentsService.GetByIdAsync(id.Value);
            if (student != null)
            {
                Student = student;
                await studentsService.RemoveAsync(student);
            }

            return RedirectToPage("./Index");
        }
    }
}
