using Moq;
using StudentAdminPortal.Application.Services.Student;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Domain.Interfaces;

namespace StudentAdminPortal.Tests.Service
{
    [TestClass]
    public class StudentsServiceTests
    {
        private Mock<IRepository<Student>> _repositoryMock;
        private StudentsService _studentsService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<Student>>();
            _studentsService = new StudentsService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnAlll()
        {
           
            var expected = new List<Student>
            {
                new Student { Id = 1, Name = "Agustin" },
                new Student { Id = 2, Name = "Tia eve" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expected);

           
            var result = await _studentsService.GetAllAsync();

           
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_Exists()
        {
           
            var student = new Student { Id = 1, Name = "Agustin" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(student);

           
            var result = await _studentsService.GetByIdAsync(1);

           
            Assert.IsNotNull(result);
            Assert.AreEqual("Agustin", result.Name);
        }

        [TestMethod]
        public void Any_StudentExists()
        {
           
            _repositoryMock.Setup(repo => repo.Any(s => s.Id == 1)).Returns(true);

           
            var exists = _studentsService.Any(1);

           
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public async Task AddAsync_AddStudent()
        {
           
            var student = new Student { Id = 3, Name = "Agustin Correa" };

           
            await _studentsService.AddAsync(student);

           
            _repositoryMock.Verify(repo => repo.AddAsync(student), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateStudent()
        {
           
            var student = new Student { Id = 1, Name = "Agusto" };

           
            await _studentsService.UpdateAsync(student);

           
            _repositoryMock.Verify(repo => repo.Update(student), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [TestMethod]
        public async Task RemoveAsync_DeleteStudent()
        {
           
            var student = new Student { Id = 1 };

           
            await _studentsService.RemoveAsync(student);

           
            _repositoryMock.Verify(repo => repo.Delete(student), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }
    }
}