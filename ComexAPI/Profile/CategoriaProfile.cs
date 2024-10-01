using AutoMapper;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;

namespace ComexAPI.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDTO, Categoria>();
        CreateMap<UpdateCategoriaDTO, Categoria>();
        CreateMap<Categoria, ReadCategoriaDTO>().ForMember(categoriaDTO => categoriaDTO.Produtos,
            opt => opt.MapFrom(categoria => categoria.Produtos));
        CreateMap<Categoria, ReadCategoriaNomeDTO>();
    }
}
