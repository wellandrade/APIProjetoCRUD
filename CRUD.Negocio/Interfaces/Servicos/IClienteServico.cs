using CRUD.Negocio.Modelos;
using System.Collections.Generic;

namespace CRUD.Negocio.Interfaces.Servicos
{
    public interface IClienteServico
    {
        Retorno ClienteValido(Cliente cliente);
        bool CadastrarCliente(Cliente cliente);
        Retorno RemoverCliente(int idCliente);
        Retorno AlterarCliente(Cliente cliente);
        bool ExisteClientePorId(int idCliente);
        IList<Cliente> ListarTodosClientes();
        Cliente ObterClientePorId(int idCliente);
    }
}
