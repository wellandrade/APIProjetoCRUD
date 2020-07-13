using CRUD.Negocio.Interfaces.Servicos;
using CRUD.Negocio.Modelos;
using CRUD.Negocio.Repositorios.Interfaces;
using CRUD.Negocio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Negocio.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        Retorno IClienteServico.ClienteValido(Cliente cliente)
        {
            var validator = new ClienteValidacao();
            var clienteValido = validator.Validate(cliente);

            if (!clienteValido.IsValid)
            {
                Retorno retorno = new Retorno(false);

                foreach (var item in clienteValido.Errors)
                {
                    retorno.AdicionarMensagemFalha(item.ErrorMessage);
                }

                return retorno;
            }

            return new Retorno(true);
        }
        bool IClienteServico.CadastrarCliente(Cliente cliente)
        {
            return _clienteRepositorio.Cadastrar(cliente);
        }
        Retorno IClienteServico.RemoverCliente(int idCliente)
        {
            Retorno retorno;

            // Pensar nisso
            if (idCliente <= 0)
            {
                retorno = new Retorno(false);
                retorno.AdicionarMensagemFalha("Nao foi possivel localizar o cliente para remover");
                return retorno;
            }

            bool removeuCliente;
            try
            {
                Cliente cliente = _clienteRepositorio.ObterClientePorId(idCliente);

                if (cliente == null)
                {
                    retorno = new Retorno(false);
                    retorno.AdicionarMensagemFalha("Nao foi possivel localizar o cliente para remover");
                    return retorno;
                }

                removeuCliente = _clienteRepositorio.Remover(cliente);
                retorno = new Retorno(true);
                retorno.AdicionarMensagemFalha("Cliente removido com sucesso");
                return retorno;
            }
            catch (Exception ex)
            {
                retorno = new Retorno(false);
                retorno.AdicionarMensagemFalha("Não foi possível remover o cliente");
                return retorno;
            }
        }
        Retorno IClienteServico.AlterarCliente(Cliente cliente)
        {
            bool efetuouAlteracao = _clienteRepositorio.Alterar(cliente);

            if (efetuouAlteracao)
            {
                return new Retorno(true);
            }

            Retorno retorno = new Retorno(false);
            retorno.AdicionarMensagemFalha("Não foi possível alterar os dados do cliente");
            return retorno;
        }
        bool IClienteServico.ExisteClientePorId(int idCliente)
        {
            Cliente cliente = _clienteRepositorio.ObterClientePorId(idCliente);

            if (cliente == null)
            {
                return false;
            }
            return true;
        }
        IList<Cliente> IClienteServico.ListarTodosClientes()
        {
            return _clienteRepositorio.ListarTodosClientes();
        }
        Cliente IClienteServico.ObterClientePorId(int idCliente)
        {
            if (idCliente <= 0)
            {
                return null;
            }

            return _clienteRepositorio.ObterClientePorId(idCliente);
        }
    }
}
