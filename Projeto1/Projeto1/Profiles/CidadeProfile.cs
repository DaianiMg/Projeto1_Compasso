using AutoMapper;
using Projeto1.Controllers.Models;
using Projeto1.Controllers.Models.Date.CidadeDtos;
using Projeto1.Controllers.Models.Date.ClienteDtos;

namespace Projeto1.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<CreateCidadeDtos, Cidade>();
            CreateMap<Cidade, ReadCidadeDtos>();
            CreateMap<UpdateCidadeDtos, Cidade>();

            CreateMap<CreateClienteDtos, Cliente>();
            CreateMap<Cliente, ReadClienteDtos>();
            CreateMap<UpdateClienteDtos, Cliente>();
        }
    }
}
