using AutoMapper;
using CRUD.API.Modelos;
using CRUD.Negocio.Interfaces.Servicos;
using CRUD.Negocio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD.API.Controllers.V1
{
    [Route("api/")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico, IMapper mapper)
        {
            _clienteServico = clienteServico;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Retorno> Cadastrar([FromBody] ClienteDto clienteDto)
        {
            Retorno retornoCliente;

            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);

                retornoCliente = _clienteServico.ClienteValido(cliente);

                if (!retornoCliente._sucesso)
                {
                    return BadRequest(retornoCliente);
                }

                bool cadastrouCliente = _clienteServico.CadastrarCliente(cliente);

                if (cadastrouCliente)
                {
                    retornoCliente = new Retorno(true);
                    retornoCliente.AdicionarMensagemSucesso("Cliente cadastrado com sucesso");
                    return Ok(retornoCliente);
                }

                retornoCliente = new Retorno(false);
                retornoCliente.AdicionarMensagemFalha("Falha ao cadastrar o cliente");
                return Ok(retornoCliente);
            }
            catch (Exception) // Gravar o Exception em log
            {
                retornoCliente = new Retorno(false);
                retornoCliente.AdicionarMensagemFalha("Falha ao gravar cliente");
                return BadRequest(retornoCliente);
            }
        }

        [HttpDelete]
        [Route("v1/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Retorno> Remover(int idCliente)
        {
            Retorno retornoCliente;

            try
            {
                retornoCliente = _clienteServico.RemoverCliente(idCliente);

                if (!retornoCliente._sucesso)
                {
                    return BadRequest(retornoCliente);
                }

                retornoCliente = new Retorno(true);
                retornoCliente.AdicionarMensagemSucesso("Cliente removido com sucesso");
                return Ok(retornoCliente);
            }
            catch (Exception) 
            {
                retornoCliente = new Retorno(false);
                retornoCliente.AdicionarMensagemFalha("Falha ao remover cliente");
                return BadRequest(retornoCliente);
            }
        }

        [HttpPut]
        [Route("v1/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Retorno> Alterar(ClienteDto clienteDto)
        {
            Retorno retornoCliente;

            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                retornoCliente = _clienteServico.ClienteValido(cliente);

                if (!retornoCliente._sucesso)
                {
                    return BadRequest(retornoCliente);
                }

                if (!_clienteServico.ExisteClientePorId(clienteDto.Id))
                {
                    retornoCliente = new Retorno(false);
                    retornoCliente.AdicionarMensagemFalha("Nao foi possivel localizar o cliente para alteração");
                    return NotFound(retornoCliente);
                }

                retornoCliente = _clienteServico.AlterarCliente(cliente);

                if (!retornoCliente._sucesso)
                {
                    return BadRequest(retornoCliente);
                }

                retornoCliente = new Retorno(true);
                retornoCliente.AdicionarMensagemSucesso("Cliente alterado com sucesso");
                return Ok(retornoCliente);
            }
            catch (Exception)  
            {
                retornoCliente = new Retorno(false);
                retornoCliente.AdicionarMensagemFalha("Falha ao remover cliente");
                return BadRequest(retornoCliente);
            }
        }

        [HttpGet]
        [Route("v1/ObterCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClienteDto> ObterCliente(int id)
        {
            try
            {
                Cliente cliente = _clienteServico.ObterClientePorId(id);

                if (cliente == null)
                {
                    return NotFound("Cliente não localizado");
                }

                return Ok(_mapper.Map<ClienteDto>(cliente));
            }
            catch (Exception) 
            {
                return BadRequest("Nao foi possível listar todos os clientes");
            }
        }
    }
}
