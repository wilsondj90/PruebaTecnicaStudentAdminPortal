namespace StudentAdminPortal.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using StudentAdminPortal.Domain.Entities;
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public DbSet<Course> Courses { get; set; }
		/// <summary>
		/// Gets or sets the RegistrationCourses.
		/// </summary>
		/// <value>
		/// The RegistrationCourses.
		/// </value>
		public DbSet<RegistrationCourse> RegistrationCourses { get; set; }
        /// <summary>
		/// Gets or sets the RegistrationCourses.
		/// </summary>
		/// <value>
		/// The RegistrationCourses.
		/// </value>
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
