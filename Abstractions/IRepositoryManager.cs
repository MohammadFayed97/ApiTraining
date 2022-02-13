namespace Abstractions;

public interface IRepositoryManager : IBaseRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
}
