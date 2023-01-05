using ERns.BusinessEntities.Entities;
using ERns.Contracts.DTO;
using AutoMapper;

public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Prod , ProdDto>(); 
    }
}
