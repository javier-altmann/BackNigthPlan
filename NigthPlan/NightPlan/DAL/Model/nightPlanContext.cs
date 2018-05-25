using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Model
{
    public partial class nightPlanContext : DbContext
    {
        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Caracteristicas> Caracteristicas { get; set; }
        public virtual DbSet<Configuraciones> Configuraciones { get; set; }
        public virtual DbSet<EstablecimientoBarrios> EstablecimientoBarrios { get; set; }
        public virtual DbSet<EstablecimientoCaracteristicas> EstablecimientoCaracteristicas { get; set; }
        public virtual DbSet<Establecimientos> Establecimientos { get; set; }
        public virtual DbSet<EstablecimientosGastronomia> EstablecimientosGastronomia { get; set; }
        public virtual DbSet<EstadoDePreferencias> EstadoDePreferencias { get; set; }
        public virtual DbSet<Gastronomia> Gastronomia { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<GruposUsuarios> GruposUsuarios { get; set; }
        public virtual DbSet<RespuestasUsuariosGrupos> RespuestasUsuariosGrupos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosAdministradores> UsuariosAdministradores { get; set; }
        public virtual DbSet<Votaciones> Votaciones { get; set; }

        public nightPlanContext(DbContextOptions<nightPlanContext> options)
            : base(options)
        { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root;Database=nightPlan;port=3306");
            }
        }
*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrios>(entity =>
            {
                entity.HasKey(e => e.IdBarrio);

                entity.ToTable("barrios");

                entity.Property(e => e.IdBarrio)
                    .HasColumnName("id_barrio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Caracteristicas>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristica);

                entity.ToTable("caracteristicas");

                entity.Property(e => e.IdCaracteristica)
                    .HasColumnName("id_caracteristica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Configuraciones>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion);

                entity.ToTable("configuraciones");

                entity.Property(e => e.IdConfiguracion)
                    .HasColumnName("id_configuracion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DireccionEstablecimientos)
                    .HasColumnName("direccion_establecimientos")
                    .HasMaxLength(500);

                entity.Property(e => e.DireccionFotosUsuarios)
                    .HasColumnName("direccion_fotos_usuarios")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<EstablecimientoBarrios>(entity =>
            {
                entity.HasKey(e => e.IdEstablecimientosBarrios);

                entity.ToTable("establecimiento_barrios");

                entity.HasIndex(e => e.IdBarrio)
                    .HasName("FK_establecimientos_barrios_to_barrios");

                entity.HasIndex(e => e.IdEstablecimiento)
                    .HasName("FK_establecimientos_barrios_to_establecimientos");

                entity.Property(e => e.IdEstablecimientosBarrios)
                    .HasColumnName("id_establecimientos_barrios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdBarrio)
                    .HasColumnName("id_barrio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstablecimiento)
                    .HasColumnName("id_establecimiento")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.EstablecimientoBarrios)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("FK_establecimientos_barrios_to_barrios");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.EstablecimientoBarrios)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .HasConstraintName("FK_establecimientos_barrios_to_establecimientos");
            });

            modelBuilder.Entity<EstablecimientoCaracteristicas>(entity =>
            {
                entity.HasKey(e => e.IdEstablecimientosCaracteristicas);

                entity.ToTable("establecimiento_caracteristicas");

                entity.HasIndex(e => e.IdCaracteristica)
                    .HasName("FK_establecimientos_gastronomia_to_caracteristicas");

                entity.HasIndex(e => e.IdEstablecimiento)
                    .HasName("FK_establecimientos_gastronomia_to_establecimientos");

                entity.Property(e => e.IdEstablecimientosCaracteristicas)
                    .HasColumnName("id_establecimientos_caracteristicas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCaracteristica)
                    .HasColumnName("id_caracteristica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstablecimiento)
                    .HasColumnName("id_establecimiento")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCaracteristicaNavigation)
                    .WithMany(p => p.EstablecimientoCaracteristicas)
                    .HasForeignKey(d => d.IdCaracteristica)
                    .HasConstraintName("FK_establecimientos_gastronomia_to_caracteristicas");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.EstablecimientoCaracteristicas)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .HasConstraintName("FK_establecimientos_gastronomia_to_establecimientos");
            });

            modelBuilder.Entity<Establecimientos>(entity =>
            {
                entity.HasKey(e => e.IdEstablecimiento);

                entity.ToTable("establecimientos");

                entity.Property(e => e.IdEstablecimiento)
                    .HasColumnName("id_establecimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Destacado)
                    .HasColumnName("destacado")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<EstablecimientosGastronomia>(entity =>
            {
                entity.HasKey(e => e.IdEstablecimientosGastronomia);

                entity.ToTable("establecimientos_gastronomia");

                entity.HasIndex(e => e.IdEstablecimiento)
                    .HasName("FK_establecimientos_gastronomia_to_establecimiento");

                entity.HasIndex(e => e.IdGastronomia)
                    .HasName("FK_establecimientos_gastronomia_to_gastronomia");

                entity.Property(e => e.IdEstablecimientosGastronomia)
                    .HasColumnName("id_establecimientos_gastronomia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstablecimiento)
                    .HasColumnName("id_establecimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGastronomia)
                    .HasColumnName("id_gastronomia")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.EstablecimientosGastronomia)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .HasConstraintName("FK_establecimientos_gastronomia_to_establecimiento");

                entity.HasOne(d => d.IdGastronomiaNavigation)
                    .WithMany(p => p.EstablecimientosGastronomia)
                    .HasForeignKey(d => d.IdGastronomia)
                    .HasConstraintName("FK_establecimientos_gastronomia_to_gastronomia");
            });

            modelBuilder.Entity<EstadoDePreferencias>(entity =>
            {
                entity.HasKey(e => e.IdEstadoDePreferencias);

                entity.ToTable("estado_de_preferencias");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("FK_crear_grupos");

                entity.Property(e => e.IdEstadoDePreferencias)
                    .HasColumnName("id_estado_de_preferencias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadUsuariosPorGrupo)
                    .HasColumnName("cantidad_usuarios_por_grupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContadorPreferenciasElegidas)
                    .HasColumnName("contador_preferencias_elegidas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.EstadoDePreferencias)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_crear_grupos");
            });

            modelBuilder.Entity<Gastronomia>(entity =>
            {
                entity.HasKey(e => e.IdGastronomia);

                entity.ToTable("gastronomia");

                entity.Property(e => e.IdGastronomia)
                    .HasColumnName("id_gastronomia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("grupos");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnName("fecha_creacion")
                    .HasMaxLength(80);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<GruposUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdGruposUsuarios);

                entity.ToTable("grupos_usuarios");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("FK_grupos_usuarios_to_usuarios");

                entity.HasIndex(e => e.IdUsuarios)
                    .HasName("FK_grupos_usuarios_to_grupos");

                entity.Property(e => e.IdGruposUsuarios)
                    .HasColumnName("id_grupos_usuarios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuarios)
                    .HasColumnName("id_usuarios")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_grupos_usuarios_to_usuarios");

                entity.HasOne(d => d.IdUsuariosNavigation)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.IdUsuarios)
                    .HasConstraintName("FK_grupos_usuarios_to_grupos");
            });

            modelBuilder.Entity<RespuestasUsuariosGrupos>(entity =>
            {
                entity.HasKey(e => e.IdRespuestasUsuario);

                entity.ToTable("respuestas_usuarios_grupos");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("FK_respuestas_usuarios_grupos_to_grupos");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_respuestas_usuarios_grupos_to_usuarios");

                entity.Property(e => e.IdRespuestasUsuario)
                    .HasColumnName("id_respuestas_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Respondio)
                    .HasColumnName("respondio")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Respuestas)
                    .IsRequired()
                    .HasColumnName("respuestas")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.RespuestasUsuariosGrupos)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_respuestas_usuarios_grupos_to_grupos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RespuestasUsuariosGrupos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_respuestas_usuarios_grupos_to_usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasMaxLength(150);

                entity.Property(e => e.ImagenPerfil)
                    .HasColumnName("imagen_perfil")
                    .HasMaxLength(150);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UsuariosAdministradores>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios_administradores");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Votaciones>(entity =>
            {
                entity.HasKey(e => e.IdVotacion);

                entity.ToTable("votaciones");

                entity.HasIndex(e => e.IdEstablecimiento)
                    .HasName("FK_votaciones_establecimientos");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("FK_votaciones_grupos");

                entity.Property(e => e.IdVotacion)
                    .HasColumnName("id_votacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaDeRespuesta)
                    .HasColumnName("fecha_de_respuesta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstablecimiento)
                    .HasColumnName("id_establecimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.Votaciones)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .HasConstraintName("FK_votaciones_establecimientos");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Votaciones)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_votaciones_grupos");
            });
        }
    }
}
