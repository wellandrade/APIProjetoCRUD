using Newtonsoft.Json;

namespace CRUD.Negocio.Modelos
{
    public class Pedido : ClasseBase
    {
        public Pedido(string descricao, float valor, int clienteId)
        {
            Descricao = descricao;
            Valor = valor;
            ClienteId = clienteId;
        }
        
        public string Descricao { get; private set; }
        public float Valor { get; private set; }
        [JsonIgnore]
        public int ClienteId { get; private set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
