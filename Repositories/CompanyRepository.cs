namespace Repositories;

using Entities;
using Abstractions;
using Entities.Models;
using System.Collections.Generic;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<Company> GetCompanies() => FindAll();
}
