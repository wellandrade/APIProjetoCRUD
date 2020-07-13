using CRUD.Negocio.Interfaces.Repositorios;
using CRUD.Negocio.Modelos;
using CRUD.Repositorio.Context;
using System;
using System.Linq;

namespace CRUD.Repositorio.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly CRUDContext _db;

        public PedidoRepositorio(CRUDContext db)
        {
            _db = db;
        }
        bool IPedidoRepositorio.Remover(Pedido pedido)
        {
            try
            {
                _db.Remove(pedido);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex) // gravar em log
            {
                return false;
            }
        }
        bool IPedidoRepositorio.Cadastrar(Pedido pedido)
        {
            try
            {
                _db.Pedidos.Add(pedido);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        Pedido IPedidoRepositorio.ObterProdutoPorId(int idPedido)
        {
            return _db.Pedidos.Where(x => x.Id == idPedido).FirstOrDefault();
        }
        bool IPedidoRepositorio.Alterar(Pedido pedido)
        {
            try
            {
                _db.Pedidos.Update(pedido);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
