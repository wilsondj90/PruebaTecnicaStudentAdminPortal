﻿namespace StudentAdminPortal.Domain.Entities
{
    public class RegistrationCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;


    }
}
