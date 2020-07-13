namespace CRUD.API.Modelos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public int ClienteId { get; set; }
    }
}
