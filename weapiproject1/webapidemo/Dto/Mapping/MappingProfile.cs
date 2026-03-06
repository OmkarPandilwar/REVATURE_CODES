using AutoMapper;
namespace webapidemo.Data;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();
    }
}