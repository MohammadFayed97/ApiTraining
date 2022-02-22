namespace Abstractions;

using Entities.Models;

public interface ICompanyRepository
{
    IEnumerable<Company> GetCompanies();
    IEnumerable<Company> GetCompaniesByIds(IEnumerable<Guid> ids);
    Company GetCompany(Guid id);
    Company GetCompanyWithEmployees(Guid id);
    void AddCompany(Company company);
}
