namespace StudentAdminPortal.Application.Services.RegistrationCourses
{
	using StudentAdminPortal.Domain.Entities;
	using StudentAdminPortal.Domain.Interfaces;
	public class RegistrationCoursesService : IRegistrationCoursesService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IRepository<RegistrationCourse> _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="RegistrationCoursesService"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		public RegistrationCoursesService(IRepository<RegistrationCourse> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <returns></returns>
		public async Task<List<RegistrationCourse>> GetAllAsync() => await _repository.GetAllAsync(c=>c.Course, s=>s.Student);

		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="registrationCourseId">The registrationCourse identifier.</param>
		/// <returns></returns>
		public async Task<RegistrationCourse> GetByIdAsync(int registrationCourseId) => await _repository.GetByIdAsync(registrationCourseId);

		/// <summary>
		/// Anies the specified registrationCourse identifier.
		/// </summary>
		/// <param name="registrationCourseId">The registrationCourse identifier.</param>
		/// <returns></returns>
		public bool Any(int registrationCourseId) => _repository.Any(i => i.Id == registrationCourseId);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		public async Task AddAsync(RegistrationCourse registrationCourse)
		{
			await _repository.AddAsync(registrationCourse);
			await _repository.SaveAsync();
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		public async Task UpdateAsync(RegistrationCourse registrationCourse)
		{
			_repository.Update(registrationCourse);
			await _repository.SaveAsync();
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		public async Task RemoveAsync(RegistrationCourse registrationCourse)
		{
			_repository.Delete(registrationCourse);
			await _repository.SaveAsync();
		}

        /// <summary>
        /// Obtain all of the student's registered subjects.
        /// </summary>
        /// /// <param name="registrationCourse">The registrationCourse.</param>

        public async Task AssociateCourseToStudentAsync(int studentId, int courseId)
        {
            var registrations = await _repository.GetAllAsync(rc => rc.Course, rc => rc.Student);
            var studentCourses = registrations
                .Where(rc => rc.StudentId == studentId)
                .ToList();

            // Valida si ya tiene 3 materias con más de 4 créditos.
            int highCreditCoursesCount = studentCourses.Count(rc => rc.Course?.Credits > 4);

            // Obtener la nueva materia
            var newCourse = studentCourses.FirstOrDefault(rc => rc.CourseId == courseId)?.Course;

            // Si no está en los registros existentes, necesitas cargarla.
            if (newCourse == null)
            {
                // Suponiendo que puedes cargar la materia directamente desde el repositorio.
                newCourse = registrations
                    .Select(rc => rc.Course)
                    .FirstOrDefault(c => c.Id == courseId);

                if (newCourse == null)
                    throw new Exception("Curso no encontrado.");
            }

            if (newCourse.Credits > 4 && highCreditCoursesCount >= 3)
            {
                throw new InvalidOperationException("El estudiante ya tiene inscritas 3 materias con más de 4 créditos.");
            }

            // Crear un nuevo registro.
            var newRegistration = new RegistrationCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _repository.AddAsync(newRegistration);
            await _repository.SaveAsync();
        }
    }
}
