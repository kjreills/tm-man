﻿using Emma.Api.Controllers;
using Emma.Api.Tests.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Emma.Api.Tests.EmployeeControllerTests;

public class BaseEmployeeControllerTest
{
    protected MockEmployeeRepository _employeeRepository = new();
    protected Mock<ILogger<EmployeeController>> _logger = new();
    protected EmployeeController _employeeController = new(new Mock<ILogger<EmployeeController>>().Object, new Mock<IEmployeeRepository>().Object);

    protected readonly Department _parksAndRec = new()
    {
        Name = "Parks and Recreation",
        Id = 1
    };

    protected readonly Department _sewage = new()
    {
        Name = "Sewage",
        Id = 2
    };

    protected readonly Designation _worker = new()
    {
        Id = 1,
        Title = "Worker"
    };

    protected readonly Designation _supervisor = new()
    {
        Id = 2,
        Title = "Supervisor"
    };

    protected Employee _tomHaverford = new();

    [TestInitialize]
    public void Setup()
    {
        _tomHaverford = new Employee
        {
            Id = 1,
            BirthDate = new DateTime(1985, 6, 20),
            HireDate = new DateTime(2004, 4, 1),
            FirstName = "Tom",
            LastName = "Haverford",
            Department = _parksAndRec,
            Designation = _worker,
            Salary = 40_000
        };

        _logger = new Mock<ILogger<EmployeeController>>();

        _employeeRepository = new MockEmployeeRepository(new List<Employee> { _tomHaverford });

        _employeeController = new EmployeeController(_logger.Object, _employeeRepository);
    }
}
