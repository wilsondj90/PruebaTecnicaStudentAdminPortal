using Moq;
using StudentAdminPortal.Application.Services.Courses;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Domain.Interfaces;
using System.Xml.Linq;

namespace CourseAdminPortal.Tests.Service
{
    [TestClass]
    public class CoursesServiceTests
    {
        private Mock<IRepository<Course>> _repositoryMock;
        private ICoursesService _coursesService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<Course>>();
            _coursesService = new CoursesService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnAlll()
        {
           
            var expected = new List<Course>
            {
                new Course { Id = 1, Code = "1", Name = "Matematicas" },
                new Course { Id = 2, Code = "2", Name = "Sociales" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expected);

           
            var result = await _coursesService.GetAllAsync();

           
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_Exists()
        {
           
            var course = new Course { Id = 1, Code = "1", Name = "Matematicas" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(course);

           
            var result = await _coursesService.GetByIdAsync(1);

           
            Assert.IsNotNull(result);
            Assert.AreEqual("Matematicas", result.Name);
        }

        [TestMethod]
        public void Any_CourseExists()
        {
           
            _repositoryMock.Setup(repo => repo.Any(s => s.Id == 1)).Returns(true);

           
            var exists = _coursesService.Any(1);

           
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public async Task AddAsync_AddCourse()
        {
           
            var course = new Course { Id = 3, Code = "1", Name = "Matematicas" };

           
            await _coursesService.AddAsync(course);

           
            _repositoryMock.Verify(repo => repo.AddAsync(course), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateCourse()
        {
           
            var course = new Course { Id = 3, Code = "2", Name = "Ciencias" };

           
            await _coursesService.UpdateAsync(course);

           
            _repositoryMock.Verify(repo => repo.Update(course), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task RemoveAsync_DeleteCourse()
        {
           
            var course = new Course { Id = 1 };

           
            await _coursesService.RemoveAsync(course);

           
            _repositoryMock.Verify(repo => repo.Delete(course), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }
    }
}