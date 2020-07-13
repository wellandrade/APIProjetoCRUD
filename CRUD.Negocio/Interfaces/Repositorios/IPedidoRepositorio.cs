using CRUD.Negocio.Modelos;

namespace CRUD.Negocio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio
    {
        bool Cadastrar(Pedido pedido);
        bool Remover(Pedido pedido);
        Pedido ObterProdutoPorId(int idPedido);
        bool Alterar(Pedido pedido);
    }
}
