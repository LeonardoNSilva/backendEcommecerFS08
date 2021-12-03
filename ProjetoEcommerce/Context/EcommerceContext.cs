using Microsoft.EntityFrameworkCore;
using ProjetoEcommerce.Entity;

namespace ProjetoEcommerce.Context
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CompraProduto> CompraProdutos { get; set; }
        public DbSet<EnderecoCliente> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=45.93.100.120,1433;initial catalog=FS08;persist security info=True;user id=FS08;password=462314;MultipleActiveResultSets=True;App=exeEf;");

        }
    }
}
