namespace Abstractions;

using Entities.Models;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployeesForCompany(Guid companyId);
    Employee GetEmployeeForCompany(Guid companyId, Guid id);
    void AddEmployee(Guid companyId, Employee employee);
}
