namespace Entities.ViewModels;

public class CompanyForCreationViewModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public IEnumerable<EmployeeForCreationViewModel> Employees { get; set; }
}
