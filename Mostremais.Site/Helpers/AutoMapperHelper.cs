﻿using AutoMapper;
using Mostremais.Domain.Entity;
using Mostremais.Site.Models;

namespace Mostremais.Site.Helpers
{
    public static class AutoMapperHelper
    {
         public static void InitializeMapper()
        {
            Mapper.Initialize(x =>
            {
                //EMPRESA
                x.CreateMap<Empresa, EmpresaViewModel>(); 
                x.CreateMap<EmpresaViewModel, Empresa>();

                //CLIENTE
                x.CreateMap<Cliente, ClienteViewModel>();
                x.CreateMap<ClienteViewModel, Cliente>();
                 
                //CATEGORIA PRODUTO
                x.CreateMap<ProdutoCategoria, ProdutoCategoriaViewModel>();
                x.CreateMap<ProdutoCategoriaViewModel, ProdutoCategoria>();
            });
        }
    }
}

/*x.CreateMap<Empresa, EmpresaViewModel>()
 .ForMember(dest => dest.nmCampoMinhaAplicacao, opt => opt.MapFrom(src => src.NomeCampoAplicacaoDestino));*/
