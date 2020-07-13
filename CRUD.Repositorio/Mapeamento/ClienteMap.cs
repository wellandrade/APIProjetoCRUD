using CRUD.Negocio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Repositorio.Mapeamento
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> cliente)
        {
            cliente.HasKey(c => c.Id);
            cliente.Property(c => c.Id).ValueGeneratedOnAdd();

            cliente.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            cliente.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cliente.HasMany(p => p.Pedidos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId);

            cliente.ToTable("Clientes");
        }
    }
}
