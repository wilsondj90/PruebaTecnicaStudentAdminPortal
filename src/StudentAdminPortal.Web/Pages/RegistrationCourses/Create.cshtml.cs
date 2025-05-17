using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Infrastructure.Persistence;
using StudentAdminPortal.Web.Pages.RegistrationCourses.ViewModels;

namespace StudentAdminPortal.Web.Pages.RegistrationCourses
{
    public class CreateModel : PageModel
    {
        private readonly StudentAdminPortal.Infrastructure.Persistence.AppDbContext _context;

        public CreateModel(StudentAdminPortal.Infrastructure.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StudentRegistrationCourseInputDto RegistrationCourse { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return ReloadPage();
            }

            var course = await _context.Courses.FindAsync(RegistrationCourse.CourseId);
            if (course == null)
            {
                ModelState.AddModelError(string.Empty, "El curso no existe.");
                return ReloadPage();
            }

            var student = await _context.Students.FindAsync(RegistrationCourse.StudentId);
            if (student == null)
            {
                ModelState.AddModelError(string.Empty, "El estudiante no existe.");
                return ReloadPage();
            }

            // Verificar si ya tiene esta materia registrada
            bool alreadyRegistered = await _context.RegistrationCourses
                .AnyAsync(rc => rc.StudentId == student.Id && rc.CourseId == course.Id);

            if (alreadyRegistered)
            {
                ModelState.AddModelError(string.Empty, "El estudiante ya tiene registrada esta materia.");
                return ReloadPage();
            }

            // Verificar materias con más de 4 créditos
            var highCreditCount = await _context.RegistrationCourses
                .Where(rc => rc.StudentId == student.Id)
                .Include(rc => rc.Course)
                .CountAsync(rc => rc.Course.Credits > 4);

            if (course.Credits > 4 && highCreditCount >= 3)
            {
                ModelState.AddModelError(string.Empty, "No se pueden inscribir más de 3 materias con más de 4 créditos.");
                return ReloadPage();
            }

            // Registrar
            var registration = new RegistrationCourse
            {
                StudentId = student.Id,
                CourseId = course.Id
            };

            _context.RegistrationCourses.Add(registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private IActionResult ReloadPage()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return Page();
        }
    }
}