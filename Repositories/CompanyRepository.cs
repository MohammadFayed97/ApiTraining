namespace Repositories;

using Entities;
using Abstractions;
using Entities.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void AddCompany(Company company) => Create(company);

    public IEnumerable<Company> GetCompanies() => FindAll();
    public IEnumerable<Company> GetCompaniesByIds(IEnumerable<Guid> ids) => FindByCondition(e => ids.Contains(e.Id));
    public Company GetCompany(Guid id) => FindByCondition(e => e.Id == id)?.FirstOrDefault();
    public Company GetCompanyWithEmployees(Guid id) => FindByCondition(e => e.Id == id)?.Include(e => e.Employees).FirstOrDefault();

}
