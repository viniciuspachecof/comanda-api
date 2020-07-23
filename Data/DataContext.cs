using System.Collections.Generic;
using ApiComanda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComanda.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Comanda> comanda { get; set; }
        public DbSet<Produto> produto { get; set; }
        public DbSet<ComandaProduto> comandaproduto { get; set; }
        public DbSet<Categoria> categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ComandaProduto>()
                            .HasKey(AD => new { AD.produtoId, AD.comandaId });

            builder.Entity<Produto>()
                .HasData(new List<Produto>(){
                    new Produto(1, "Pão", 1.23, 1)
                });

            builder.Entity<Comanda>()
                .HasData(new List<Comanda>{
                    new Comanda(1, 1, 1, 'A')
                });

            builder.Entity<ComandaProduto>()
                .HasData(new List<ComandaProduto>{
                    new ComandaProduto() {produtoId = 1, comandaId = 1}
                });

            builder.Entity<Categoria>()
            .HasData(new List<Categoria>{
                    new Categoria(1, "Alimento")
            });
        }
    }
};