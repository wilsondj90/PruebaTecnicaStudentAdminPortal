using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Infrastructure.Persistence;

namespace StudentAdminPortal.Web.Pages.Students
{
    public class EditModel : PageModel
    {
        /// <summary>
        /// The students service
        /// </summary>
        private readonly IStudentsService studentsService;

        public EditModel(IStudentsService _studentsService)
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
                await studentsService.UpdateAsync(student: Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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
        /// Students the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool StudentExists(int id)
        {
            return studentsService.Any(id);
        }
    }
}
