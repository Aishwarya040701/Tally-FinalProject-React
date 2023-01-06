using AutoFixture;
using EmployeeEFCore.Controllers;
using EmployeeEFCore.Interface;
using EmployeeEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace EmployeeXunitMoqTest
{
    public class EmployeeControllerTest
    {
        //private readonly IEmployeeRepo 
        private Mock<IEmployeeRepo> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeesController _controller;

        public EmployeeControllerTest()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployeeRepo>();
        }

        [Fact]
        public async Task Get_Employee_Return_Ok()
        {
            var employeeList = _fixture.CreateMany<Employee>(3).ToList();
            _employeeRepoMock.Setup(repo => repo.GetEmployees()).Returns(employeeList);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.GetEmployees();
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }


        [Fact]
        public async Task Get_Employee_ThrowException()
        {

            _employeeRepoMock.Setup(repo => repo.GetEmployees()).Throws(new Exception());
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.GetEmployees();
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }

        [Fact]
        public async Task Get_EmployeeById_Return_Ok()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.GetEmployeeById(employee.EmployeeId)).Returns(employee);
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.GetEmployee(employee.EmployeeId);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Get_EmployeeById_Return_NotFound()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.GetEmployeeById(employee.EmployeeId)).Returns(employee);
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(false);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.GetEmployee(employee.EmployeeId);
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }

        [Fact]
        public async Task Get_EmployeeById_ThrowException()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.GetEmployeeById(employee.EmployeeId)).Throws(new Exception());
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.GetEmployee(employee.EmployeeId);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
        [Fact]
        public async Task Post_Employee_Return_Ok()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.PostEmployee(It.IsAny<Employee>())).Returns(employee);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.PostEmployee(It.IsAny<Employee>());
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Post_Employee_ThrowException()
        {

            _employeeRepoMock.Setup(repo => repo.PostEmployee(It.IsAny<Employee>())).Throws(new Exception());
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.PostEmployee(It.IsAny<Employee>());
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }

        [Fact]
        public async Task Put_Employee_Return_Ok()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.PutEmployee(It.IsAny<Employee>())).Returns(employee);
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.PutEmployee(employee.EmployeeId, employee);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Put_Employee_Return_NotFound()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.PutEmployee(It.IsAny<Employee>())).Returns(employee);
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(false);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.PutEmployee(employee.EmployeeId, employee);
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }

        [Fact]
        public async Task Put_Employee_ThrowException()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.PutEmployee(It.IsAny<Employee>())).Throws(new Exception());
            _employeeRepoMock.Setup(repo => repo.checkId(It.IsAny<int>())).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.PutEmployee(employee.EmployeeId, employee);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }



        [Fact]
        public async Task Delete_Employee_Return_Ok()
        {
            //var employee = _fixture.Create<EmployeeDTO>();
            _employeeRepoMock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>())).Returns(true);
            _employeeRepoMock.Setup(repo => repo.checkId(It.IsAny<int>())).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Delete_Employee_Return_NotFound()
        {
            var employee = _fixture.Create<Employee>();
            _employeeRepoMock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>())).Returns(true);
            _employeeRepoMock.Setup(repo => repo.checkId(employee.EmployeeId)).Returns(false);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }

        [Fact]
        public async Task Delete_Employee_ThrowException()
        {

            _employeeRepoMock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>())).Throws(new Exception());
            _employeeRepoMock.Setup(repo => repo.checkId(It.IsAny<int>())).Returns(true);
            _controller = new EmployeesController(_employeeRepoMock.Object);

            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
    }
}
