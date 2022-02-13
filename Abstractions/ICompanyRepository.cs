namespace Abstractions;

using Entities.Models;

public interface ICompanyRepository
{
    IEnumerable<Company> GetCompanies();
}
