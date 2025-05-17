namespace StudentAdminPortal.Application.Services.Student
{
    using StudentAdminPortal.Domain.Entities;
    using StudentAdminPortal.Domain.Interfaces;
    public class StudentsService : IStudentsService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository<Student> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public StudentsService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetAllAsync() => await _repository.GetAllAsync();

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        public async Task<Student> GetByIdAsync(int studentId) => await _repository.GetByIdAsync(studentId);

        /// <summary>
        /// Anies the specified student identifier.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        public bool Any(int studentId) => _repository.Any(i => i.Id == studentId);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        public async Task AddAsync(Student student)
        {
            await _repository.AddAsync(student);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        public async Task UpdateAsync(Student student)
        {
            _repository.Update(student);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="student">The student.</param>
        public async Task RemoveAsync(Student student)
        {
            _repository.Delete(student);
            await _repository.SaveAsync();
        }
    }
}
