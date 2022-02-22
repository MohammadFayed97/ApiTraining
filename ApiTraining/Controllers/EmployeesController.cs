namespace ApiTraining.Controllers;

using Abstractions;
using AutoMapper;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

[Route("api/Company/{companyId}/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEmployees(Guid companyId)
    {
        IEnumerable<Employee> employees = _repository.Employee.GetEmployeesForCompany(companyId);
        
        return Ok(_mapper.Map<IEnumerable<EmployeeViewModel>>(employees));
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public IActionResult GetEmployee(Guid companyId, Guid id)
    {
        Employee employee = _repository.Employee.GetEmployeeForCompany(companyId, id);

        EmployeeViewModel employeeToReturn = _mapper.Map<EmployeeViewModel>(employee);

        return Ok(employeeToReturn);
    }

    [HttpPost]
    public IActionResult CreateEmployee(Guid companyId, [FromBody]EmployeeForCreationViewModel employeeForCreation)
    {
        if(employeeForCreation == null)
        {
            _logger.LogError("EmployeeForCreation object sent from client is null");
            return BadRequest("EmployeeForCreation object is null");
        }
        if(_repository.Company.GetCompany(companyId) == null)
        {
            string message = $"Company with id {companyId} dosn't exist in th database";
            _logger.LogError(message);
            return NotFound(message);
        }
        Employee employeeEntity = _mapper.Map<Employee>(employeeForCreation);

        _repository.Employee.AddEmployee(companyId, employeeEntity);
        _repository.Save();

        EmployeeViewModel employeeToReturn = _mapper.Map<EmployeeViewModel>(employeeEntity);
        return CreatedAtRoute("GetEmployeeById", new { companyId = companyId, id = employeeToReturn.Id }, employeeToReturn);
    }
}