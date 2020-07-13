using CRUD.Negocio.Modelos;
using System.Collections;
using System.Collections.Generic;

namespace CRUD.Negocio.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        bool Cadastrar(Cliente cliente);
        bool Remover(Cliente cliente);
        Cliente ObterClientePorId(int idCliente);
        bool Alterar(Cliente cliente);
        IList<Cliente> ListarTodosClientes();
    }
}
