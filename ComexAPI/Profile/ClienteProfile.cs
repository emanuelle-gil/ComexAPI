using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using AutoMapper;

namespace ComexAPI.Profiles;

public class ClienteProfile : Profile
{
	public ClienteProfile()
	{
        CreateMap<CreateClienteDTO, Cliente>();
        CreateMap<UpdateClienteDTO, Cliente>();
        CreateMap<Cliente, ReadClienteDTO>().ForMember(clienteDTO => clienteDTO.Endereco,
                    opt => opt.MapFrom(cliente => cliente.Endereco));
    }
}
