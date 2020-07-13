using AutoMapper;
using CRUD.API.Modelos;
using CRUD.Negocio.Interfaces;
using CRUD.Negocio.Interfaces.Servicos;
using CRUD.Negocio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD.API.Controllers.V1
{
    [Route("api/")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPedidoServico _pedidoServico;

        public PedidoController(IPedidoServico pedidoServico, IMapper mapper)
        {
            _pedidoServico = pedidoServico;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/Pedido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pedido> Cadastrar([FromBody] PedidoDto pedidoDto)
        {
            Retorno retornoPedido;

            Pedido pedido = _mapper.Map<Pedido>(pedidoDto);

            retornoPedido = _pedidoServico.PedidoValido(pedido);

            if (!retornoPedido._sucesso)
            {
                return BadRequest(retornoPedido);
            }

            bool produtoCadastrado = _pedidoServico.CadastraPedido(pedido);
            if (produtoCadastrado)
            {
                retornoPedido = new Retorno(true);
                retornoPedido.AdicionarMensagemSucesso("Pedido cadastrado com sucesso");
                return Ok(retornoPedido);
            }

            retornoPedido = new Retorno(false);
            retornoPedido.AdicionarMensagemFalha("Falha ao cadastrar o pedido do cliente");

            return BadRequest(retornoPedido);
        }

        [HttpDelete]
        [Route("v1/Produto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Retorno> Remover(int idPedido)
        {
            Retorno retornoPedido;

            try
            {
                retornoPedido = _pedidoServico.RemoverPedido(idPedido);

                if (!retornoPedido._sucesso)
                {
                    return BadRequest(retornoPedido);
                }

                retornoPedido = new Retorno(true);
                retornoPedido.AdicionarMensagemSucesso("Pedido removido com sucesso");
                return Ok(retornoPedido);
            }
            catch (Exception) 
            {
                retornoPedido = new Retorno(false);
                retornoPedido.AdicionarMensagemFalha("Falha ao remover o pedido do cliente");
                return BadRequest(retornoPedido);
            }
        }
    }
}
