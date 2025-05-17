namespace StudentAdminPortal.Application.Services.Student
{
    using StudentAdminPortal.Domain.Entities;
    public interface IStudentsService
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GetAllAsync();

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        Task<Student> GetByIdAsync(int studentId);

        /// <summary>
        /// Anies the specified student identifier.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        bool Any(int studentId);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task AddAsync(Student student);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task UpdateAsync(Student student);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        Task RemoveAsync(Student student);
    }
}
