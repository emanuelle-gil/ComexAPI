﻿using AutoMapper;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;

namespace ComexAPI.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDTO, Produto>();
        CreateMap<UpdateProdutoDTO, Produto>();
        CreateMap<Produto, ReadProdutoDTO>()
            .ForMember(produtoDTO => produtoDTO.Categoria,
                       opt => opt.MapFrom(produto => produto.Categoria));
    }
}
