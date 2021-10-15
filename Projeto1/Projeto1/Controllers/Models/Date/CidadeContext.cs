using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto1.Controllers.Models.Date
{
    public class CidadeContext : DbContext
    {
        public CidadeContext(DbContextOptions<CidadeContext> opt) : base(opt)
        {
        }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog = Projeto1; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>(entity =>
            {

                entity.ToTable("cidade");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id)
                .HasColumnName("Id");

                entity.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasColumnType("varchar(100)");

                entity.Property(c => c.Estado)
                .HasColumnName("Estado")
                .IsRequired()
                .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.Property(e => e.Id)
                .HasColumnName("Id");

                entity.Property(e => e.CidadeId)
                .HasColumnName("CidadeId");


                entity.Property(c => c.Nome)
               .HasColumnName("Nome")
               .IsRequired()
               .HasColumnType("varchar(100)");

                entity.Property<DateTime>("Data_Nascimento")
                .HasColumnType("Data_Nascimento")
                .HasDefaultValueSql("getdate()")
                .IsRequired();


                entity.Property(c => c.Cep)
               .HasColumnName("Cep")
               .IsRequired()
               .HasColumnType("varchar(10)");

                entity.Property(c => c.Logradouro)
               .HasColumnName("Logradouro")
               //.IsRequired()
               .HasColumnType("varchar(100)");

                entity.Property(c => c.Bairro)
               .HasColumnName("Bairro")
               //.IsRequired()
               .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Cidade)
                .WithMany(p => p.Cliente)
                .HasForeignKey(d => d.CidadeId)
                .HasPrincipalKey(d =>d.Id);

            });

        }

    }

}
