using StudentAdminPortal.Domain.Entities;

namespace StudentAdminPortal.Application.Services.RegistrationCourses
{
	using StudentAdminPortal.Domain.Entities;
	public interface IRegistrationCoursesService
	{
		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<List<RegistrationCourse>> GetAllAsync();

		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="registrationCourseId">The registrationCourse identifier.</param>
		/// <returns></returns>
		Task<RegistrationCourse> GetByIdAsync(int registrationCourseId);

		/// <summary>
		/// Anies the specified registrationCourse identifier.
		/// </summary>
		/// <param name="registrationCourseId">The registrationCourse identifier.</param>
		/// <returns></returns>
		bool Any(int registrationCourseId);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		/// <returns></returns>
		Task AddAsync(RegistrationCourse registrationCourse);

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		/// <returns></returns>
		Task UpdateAsync(RegistrationCourse registrationCourse);

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="registrationCourse">The registrationCourse.</param>
		/// <returns></returns>
		Task RemoveAsync(RegistrationCourse registrationCourse);

        /// <summary>
        /// Associates subject to student, validating credits.
        /// </summary>
        /// <param name="studentId">IdStudent</param>
        /// <param name="subjectId">Idcourse</param>
        Task AssociateCourseToStudentAsync(int studentId, int subjectId);
    }
}
