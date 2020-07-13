using CRUD.Negocio.Modelos;

namespace CRUD.Negocio.Interfaces.Servicos
{
    public interface IPedidoServico
    {
        Retorno PedidoValido(Pedido pedido);
        bool CadastraPedido(Pedido pedido);
        Pedido ObterPedido(int idPedido);
        Retorno RemoverPedido(int idPedido);
        Retorno AlterarPedido(Pedido pedido);
    }
}
