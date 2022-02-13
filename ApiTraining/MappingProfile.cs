namespace ApiTraining;

using AutoMapper;
using Entities.Models;
using Entities.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyViewModel>()
            .ForMember(e => e.FullAddress, 
                option => option.MapFrom(x => string.Join(", ", x.Address, x.Country)));
    }
}