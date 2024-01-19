using Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Empleados.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estatus> Estatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estatus>().HasData(new Estatus
            {
                Estatus_Id = 1,
                Descripcion = "Activo"
            });
            modelBuilder.Entity<Estatus>().HasData(new Estatus
            {
                Estatus_Id = 2,
                Descripcion = "No Activo"
            });
        }
    }
}
