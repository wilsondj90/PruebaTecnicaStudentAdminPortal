using Moq;
using StudentAdminPortal.Application.Services.RegistrationCourses;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Domain.Interfaces;

namespace StudentAdminPortal.Tests.Service
{
    [TestClass]
    public class RegistrationCoursesServiceTests
    {
        private Mock<IRepository<RegistrationCourse>> _repositoryMock;
        private RegistrationCoursesService _registrationCoursesService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<RegistrationCourse>>();
            _registrationCoursesService = new RegistrationCoursesService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnAlll()
        {
           
            var expected = new List<RegistrationCourse>
            {
                new RegistrationCourse { Id = 1, StudentId = 1 },
                new RegistrationCourse { Id = 2, StudentId = 2 }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expected);

           
            var result = await _registrationCoursesService.GetAllAsync();

           
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_Exists()
        {
           
            var student = new RegistrationCourse { Id = 1, StudentId = 2 };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(student);

           
            var result = await _registrationCoursesService.GetByIdAsync(1);

           
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.StudentId);
        }

        [TestMethod]
        public void Any_StudentregistrationCourse()
        {
           
            _repositoryMock.Setup(repo => repo.Any(s => s.Id == 1)).Returns(true);

           
            var exists = _registrationCoursesService.Any(1);

           
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public async Task AddAsync_AddregistrationCourse()
        {
           
            var registrationCourse = new RegistrationCourse { Id = 3, StudentId = 2 };

           
            await _registrationCoursesService.AddAsync(registrationCourse);

           
            _repositoryMock.Verify(repo => repo.AddAsync(registrationCourse), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateregistrationCourse()
        {
           
            var registrationCourse = new RegistrationCourse { Id = 1, StudentId = 5 };

           
            await _registrationCoursesService.UpdateAsync(registrationCourse);

           
            _repositoryMock.Verify(repo => repo.Update(registrationCourse), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task RemoveAsync_DeleteregistrationCourse()
        {
           
            var registrationCourse = new RegistrationCourse { Id = 1 };

           
            await _registrationCoursesService.RemoveAsync(registrationCourse);

           
            _repositoryMock.Verify(repo => repo.Delete(registrationCourse), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }
    }
}