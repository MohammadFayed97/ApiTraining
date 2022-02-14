namespace ApiTraining.Controllers;

using Abstractions;
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
        this._repository = repository;
        this._logger = logger;
        this._mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        IEnumerable<CompanyViewModel> companies = _mapper.Map<IEnumerable<CompanyViewModel>>(_repository.Company.GetCompanies());

        return Ok(companies);
    }
}