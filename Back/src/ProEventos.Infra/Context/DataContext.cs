using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Infra.Entities;

namespace ProEventos.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
       public DbSet<Evento> Eventos { get; set; } 
       public DbSet<Lote> Lotes { get; set; }
       public DbSet<Palestrante> Palestrantes { get; set; }
       public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
       public DbSet<RedeSocial> RedesSociais { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(a => new {a.EventoId, a.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(e => e.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(e => e.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}