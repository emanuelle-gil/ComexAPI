using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using AutoMapper;

namespace ComexAPI.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDTO, Endereco>();
        CreateMap<UpdateEnderecoDTO, Endereco>();
        CreateMap<Endereco, ReadEnderecoDTO>();
    }
}
