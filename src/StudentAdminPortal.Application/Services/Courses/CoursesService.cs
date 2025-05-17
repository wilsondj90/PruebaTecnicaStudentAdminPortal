namespace StudentAdminPortal.Application.Services.Courses
{

	using StudentAdminPortal.Domain.Entities;
	using StudentAdminPortal.Domain.Interfaces;
	public class CoursesService : ICoursesService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IRepository<Course> _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="StudentsService"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		public CoursesService(IRepository<Course> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <returns></returns>
		public async Task<List<Course>> GetAllAsync() => await _repository.GetAllAsync();

		/// <summary>
		/// Gets the by identifier asynchronous.
		/// </summary>
		/// <param name="courseId">The course identifier.</param>
		/// <returns></returns>
		public async Task<Course> GetByIdAsync(int courseId) => await _repository.GetByIdAsync(courseId);

		/// <summary>
		/// Anies the specified course identifier.
		/// </summary>
		/// <param name="courseId">The course identifier.</param>
		/// <returns></returns>
		public bool Any(int courseId) => _repository.Any(i => i.Id == courseId);

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		public async Task AddAsync(Course course)
		{
			await _repository.AddAsync(course);
			await _repository.SaveAsync();
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		public async Task UpdateAsync(Course course)
		{
			_repository.Update(course);
			await _repository.SaveAsync();
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="course">The course.</param>
		public async Task RemoveAsync(Course course)
		{
			_repository.Delete(course);
			await _repository.SaveAsync();
		}
	}
}
