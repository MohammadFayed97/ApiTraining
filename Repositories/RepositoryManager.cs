namespace Repositories;

using Entities;
using Abstractions;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _context;
    private ICompanyRepository _companyRepository;
    private IEmployeeRepository _employeeRepository;

    public RepositoryManager(ApplicationDbContext context) => _context = context;

    public ICompanyRepository Company
    {
        get
        {
            if(_companyRepository == null )
                _companyRepository = new CompanyRepository(_context);

            return _companyRepository;
        }
    }

    public IEmployeeRepository Employee
    {
        get
        {
            if(_employeeRepository == null)
                _employeeRepository = new EmployeeRepository(_context);

            return _employeeRepository;
        }
    }

    public void Save() => _context.SaveChanges();
}
