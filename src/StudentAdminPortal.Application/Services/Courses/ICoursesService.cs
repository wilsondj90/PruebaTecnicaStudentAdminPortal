namespace StudentAdminPortal.Application.Services.Courses
{
	using StudentAdminPortal.Domain.Entities;
	public interface ICoursesService
	{
		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<List<Course>> GetAllAsync();

		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="courseId">The course identifier.</param>
		/// <returns></returns>
		Task<Course> GetByIdAsync(int courseId);

		/// <summary>
		/// Anies the specified course identifier.
		/// </summary>
		/// <param name="courseId">The course identifier.</param>
		/// <returns></returns>
		bool Any(int courseId);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		/// <returns></returns>
		Task AddAsync(Course course);

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		/// <returns></returns>
		Task UpdateAsync(Course course);

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		/// <returns></returns>
		Task RemoveAsync(Course course);
	}
}