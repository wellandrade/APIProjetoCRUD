using AutoMapper;
using CRUD.API.Modelos;
using CRUD.Negocio.Modelos;

namespace CRUD.API.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
        }
    }
}
