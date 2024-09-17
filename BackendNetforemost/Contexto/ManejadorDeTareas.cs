using Microsoft.EntityFrameworkCore;
using Entidad;

namespace BackendNetforemost.Contexto
{
    public class ManejadorDeTareas : DbContext
    {
        public ManejadorDeTareas(DbContextOptions<ManejadorDeTareas> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Tareas)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId);

            modelBuilder.Entity<Prioridad>()
                .HasMany(p => p.Tareas)
                .WithOne(t => t.Prioridad)
                .HasForeignKey(t => t.PrioridadId);

            // Agregar datos iniciales a la tabla Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Correo = "juan@asd.asd",
                    Telefono = "123456789",
                    Created_At = System.DateTime.Now,
                    Updated_At = System.DateTime.Now
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Maria",
                    Apellido = "Gomez",
                    Correo = "maria@asdas.asd",
                    Telefono = "987654321",
                    Created_At = System.DateTime.Now,
                    Updated_At = System.DateTime.Now
                }
            );

            // Agregar datos iniciales a la tabla Prioridades
            modelBuilder.Entity<Prioridad>().HasData(
                new Prioridad
                {
                    Id = 1,
                    Nombre = "Alta"
                },
                new Prioridad
                {
                    Id = 2,
                    Nombre = "Media"
                },
                new Prioridad
                {
                    Id = 3,
                    Nombre = "Baja"
                }
            );

            // Agregar datos iniciales a la tabla Tareas
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = 1,
                    UsuarioId = 1,
                    Titulo = "Tarea 1",
                    Descripcion = "Descripcion de la tarea 1",
                    FechaVencimiento = System.DateTime.Now,
                    Finalizado = false,
                    Eliminado = false,
                    Tags = "tag1, tag2",
                    PrioridadId = 1,
                    Created_At = System.DateTime.Now,
                    Updated_At = System.DateTime.Now
                },
                new Tarea
                {
                    Id = 2,
                    UsuarioId = 1,
                    Titulo = "Tarea 2",
                    Descripcion = "Descripcion de la tarea 2",
                    FechaVencimiento = System.DateTime.Now,
                    Finalizado = false,
                    Eliminado = false,
                    Tags = "tag1, tag2",
                    PrioridadId = 2,
                    Created_At = System.DateTime.Now,
                    Updated_At = System.DateTime.Now
                },
                new Tarea
                {
                    Id = 3,
                    UsuarioId = 2,
                    Titulo = "Tarea 3",
                    Descripcion = "Descripcion de la tarea 3",
                    FechaVencimiento = System.DateTime.Now,
                    Finalizado = false,
                    Eliminado = false,
                    Tags = "tag1, tag2",
                    PrioridadId = 3,
                    Created_At = System.DateTime.Now,
                    Updated_At = System.DateTime.Now
                }
            );
        }
    }
}