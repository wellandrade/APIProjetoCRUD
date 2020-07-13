using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CRUD.Negocio.Modelos
{
    public class Cliente : ClasseBase
    {
        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
     
        public string Nome { get; private set; }
        public string Email { get; private set; }
        [JsonIgnore]
        public IList<Pedido> Pedidos { get; private set; }
    }
}
