using CRUD.Negocio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Repositorio.Mapeamento
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> pedido)
        {
            pedido.HasKey(p => p.Id);
            pedido.Property(p => p.Id).ValueGeneratedOnAdd();

            pedido.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            pedido.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("float");

            pedido.ToTable("Pedidos");
        }
    }
}
