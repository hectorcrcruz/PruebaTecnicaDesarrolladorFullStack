using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Persistence
{
    public class TareaDbContext : DbContext
    {
        public TareaDbContext(DbContextOptions options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Registros creados por defecto en la base de datos
            List<Tarea> tareas = new List<Tarea>();
            tareas.Add(new Tarea
            {
                Id = 1,
                Titulo = "Tarea 1",
                FechaCreacion = DateTime.Now,
                Descripcion = "Tareas diarias",
            });


            #endregion
        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
