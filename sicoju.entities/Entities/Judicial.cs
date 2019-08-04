using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace sicoju.entities.Entities
{
    public partial class Judicial : DbContext
    {
        public virtual DbSet<Caso> Caso { get; set; }
        public virtual DbSet<DetalleCaso> DetalleCaso { get; set; }
        public virtual DbSet<Formulario> Formulario { get; set; }
        public virtual DbSet<FormularioPerfil> FormularioPerfil { get; set; }
        public virtual DbSet<Involucrado> Involucrado { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<TipoCaso> TipoCaso { get; set; }
        public virtual DbSet<TipoInvolucrado> TipoInvolucrado { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public virtual DbSet<UsuarioTipoCaso> UsuarioTipoCaso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caso>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Caso>()
                .Property(e => e.Sentencia)
                .IsUnicode(false);

            modelBuilder.Entity<Formulario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Formulario>()
                .Property(e => e.Ruta)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.PrimerApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.SegundoApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Involucrado>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCaso>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoInvolucrado>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PrimerApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.SegundoApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Caso)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.JuezID);
        }
    }
}
