using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tarefa_bd_parte1
{
    public class MainDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuario => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Usuario>().ToTable("Usuario").Property(p => p.Cpf).HasColumnName("cpf");
            modelBuilder.Entity<Usuario>().ToTable("Usuario").Property(p => p.Nome).HasColumnName("nome");
            modelBuilder.Entity<Usuario>().ToTable("Usuario").Property(p => p.Data_Nascimento).HasColumnName("data_nascimento");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    "User ID=postgres;Password=7hELjWbk4mXeM&;Host=database-1.cjl7wuocylmp.us-east-1.rds.amazonaws.com;Port=5432;Database=tarefa-usuario;Pooling=true;Connection Lifetime=0;"
                )
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Usuario
    {   
        [Key]
        public int Cpf { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateTime Data_Nascimento { get; set; }
    }
}
