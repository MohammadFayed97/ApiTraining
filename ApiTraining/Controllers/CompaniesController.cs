namespace ApiTraining.Controllers;

using Abstractions;
using ApiTraining.ModelBinders;
using AutoMapper;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        IEnumerable<CompanyViewModel> companies = _mapper.Map<IEnumerable<CompanyViewModel>>(_repository.Company.GetCompanies());

        return Ok(companies);
    }

    [HttpGet("collection/{ids}", Name = "CompanyCollection")]
    public IActionResult GetCompany([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        if (ids == null)
        {
            _logger.LogError("ids is null");
            return BadRequest();
        }

        IEnumerable<CompanyViewModel> companies = _mapper.Map<IEnumerable<CompanyViewModel>>(_repository.Company.GetCompaniesByIds(ids));

        if (ids.Count() != companies.Count())
        {
            _logger.LogError("Some ids are not valid in a collection");
            return NotFound();
        }
        return Ok(companies);
    }

    [HttpGet("{id}", Name = "CompanyById")]
    public IActionResult GetCompany(Guid id)
    {
        CompanyViewModel company = _mapper.Map<CompanyViewModel>(_repository.Company.GetCompany(id));

        return Ok(company);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationViewModel companyForCreation)
    {
        if (companyForCreation == null)
        {
            _logger.LogError("CompanyForCreation object sent from client is null");
            return BadRequest("CompanyForCreation object is null");
        }

        Company companyEntity = _mapper.Map<Company>(companyForCreation);
        _repository.Company.AddCompany(companyEntity);
        _repository.Save();

        CompanyViewModel companyToReturn = _mapper.Map<CompanyViewModel>(companyEntity);
        return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id }, companyToReturn);
    }
    [HttpPost("Collection")]
    public IActionResult CreateCompany([FromBody] IEnumerable<CompanyForCreationViewModel> companiesForCreation)
    {
        if (companiesForCreation == null)
        {
            _logger.LogError("CompaniesForCreation collection sent from client is null");
            return BadRequest("CompaniesForCreation collection is null");
        }

        IEnumerable<Company> companiesEntity = _mapper.Map<IEnumerable<Company>>(companiesForCreation);
        foreach (Company company in companiesEntity)
        {
            _repository.Company.AddCompany(company);
        }
        _repository.Save();

        IEnumerable<CompanyViewModel> companiesToReturn = _mapper.Map<IEnumerable<CompanyViewModel>>(companiesEntity);
        string ids = string.Join(",", companiesToReturn.Select(e => e.Id));

        return CreatedAtRoute("CompanyCollection", new { ids }, companiesToReturn);
    }
}