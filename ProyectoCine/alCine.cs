namespace ProyectoCine
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class alCine : DbContext
    {
        public alCine()
            : base("name=contextalCine")
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; }
        public virtual DbSet<Cartelera> Carteleras { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Sede> Sedes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Versione> Versiones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacione>()
                .HasMany(e => e.Peliculas)
                .WithRequired(e => e.Calificacione)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.Peliculas)
                .WithRequired(e => e.Genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pelicula>()
                .HasMany(e => e.Carteleras)
                .WithRequired(e => e.Pelicula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pelicula>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Pelicula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Carteleras)
                .WithRequired(e => e.Sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposDocumento>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.TiposDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Versione>()
                .HasMany(e => e.Carteleras)
                .WithRequired(e => e.Versione)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Versione>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Versione)
                .WillCascadeOnDelete(false);
        }
    }
}
