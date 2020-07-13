using CRUD.Negocio.Modelos;
using CRUD.Negocio.Repositorios.Interfaces;
using CRUD.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Repositorio.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio 
    {
        private readonly CRUDContext _db;

        public ClienteRepositorio(CRUDContext db)
        {
            _db = db;
        }
        bool IClienteRepositorio.Alterar(Cliente cliente)
        {
            try
            {
                _db.Entry(cliente).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex) // gravar em log
            {
                return false;
            }
        }
        bool IClienteRepositorio.Cadastrar(Cliente cliente)
        {
            try
            {
                _db.Clientes.Add(cliente);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool IClienteRepositorio.Remover(Cliente cliente)
        {
            try
            {
                _db.Remove(cliente);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        Cliente IClienteRepositorio.ObterClientePorId(int idCliente)
        {
            try
            {
                return _db.Clientes.AsNoTracking().Where(x => x.Id == idCliente).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        IList<Cliente> IClienteRepositorio.ListarTodosClientes()
        {
            return _db.Clientes.AsNoTracking().ToList();
        }
    }
}
