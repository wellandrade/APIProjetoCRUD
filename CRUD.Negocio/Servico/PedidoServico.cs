using CRUD.Negocio.Interfaces.Repositorios;
using CRUD.Negocio.Interfaces.Servicos;
using CRUD.Negocio.Modelos;
using CRUD.Negocio.Validacoes;
using System;

namespace CRUD.Negocio.Servico
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoServico(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        bool IPedidoServico.CadastraPedido(Pedido pedido)
        {
            return _pedidoRepositorio.Cadastrar(pedido);
        }
        Retorno IPedidoServico.PedidoValido(Pedido pedido)
        {
            var validator = new PedidoValidacao();
            var produtoValido = validator.Validate(pedido);

            if (!produtoValido.IsValid)
            {
                Retorno retorno = new Retorno(false);

                foreach (var item in produtoValido.Errors)
                {
                    retorno.AdicionarMensagemFalha(item.ErrorMessage);
                }

                return retorno;
            }

            return new Retorno(true);
        }
        Pedido IPedidoServico.ObterPedido(int idPedido)
        {
            return _pedidoRepositorio.ObterProdutoPorId(idPedido);
        }
        Retorno IPedidoServico.RemoverPedido(int idPedido)
        {
            Retorno retorno;

            if (idPedido <= 0)
            {
                retorno = new Retorno(false);
                retorno.AdicionarMensagemFalha("Nao foi possivel localizar o pedido para remover");
                return retorno;
            }

            bool removeuCliente;
            try
            {
                Pedido pedido = _pedidoRepositorio.ObterProdutoPorId(idPedido);

                if (pedido == null)
                {
                    retorno = new Retorno(false);
                    retorno.AdicionarMensagemFalha("Nao foi possivel localizar o pedido para remover");
                    return retorno;
                }

                removeuCliente = _pedidoRepositorio.Remover(pedido);
                retorno = new Retorno(true);
                retorno.AdicionarMensagemFalha("pedido removido com sucesso");
                return retorno;
            }
            catch (Exception ex)
            {
                retorno = new Retorno(false);
                retorno.AdicionarMensagemFalha("Não foi possível remover o pedido");
                return retorno;
            }


        }
        Retorno IPedidoServico.AlterarPedido(Pedido pedido)
        {
            bool efetuouAlteracao = _pedidoRepositorio.Alterar(pedido);

            if (efetuouAlteracao)
            {
                return new Retorno(true);
            }

            Retorno retorno = new Retorno(false);
            retorno.AdicionarMensagemFalha("Não foi possível alterar os dados do pedido");
            return retorno;
        }
    }
}
