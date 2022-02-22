namespace Repositories;

using Entities;
using Abstractions;
using Entities.Models;
using System.Collections.Generic;
using System;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
    public void AddEmployee(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public Employee GetEmployeeForCompany(Guid companyId, Guid id) => FindByCondition(e => e.Id == id && e.CompanyId == companyId).FirstOrDefault();

    public IEnumerable<Employee> GetEmployeesForCompany(Guid companyId) => FindByCondition(e => e.CompanyId == companyId);
}
