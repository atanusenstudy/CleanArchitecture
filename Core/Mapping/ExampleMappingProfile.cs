using AutoMapper;
using Core.Aggregate.DTOs;
using Core.Aggregate.Entities;

namespace Core.Mapping;

public class ExampleMappingProfile : Profile
{
    public ExampleMappingProfile()
    {
        CreateMap<ExampleDTO, Example>();
        CreateMap<Example, ExampleDetailsDTO>().ForCtorParam(nameof(ExampleDetailsDTO.Id), opt =>opt.MapFrom(src => src.Id));
        /*
        CreateMap<ExampleDTO, Example>();
        CreateMap<ExampleDTO, Example>();
        */
    }
}
