using demoapp.BusinessEntities.Entities;
using demoapp.Contracts.DTO;
using AutoMapper;

public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Prod , ProdDto>(); 
    }
}
