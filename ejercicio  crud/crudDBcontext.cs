using ejercicio__crud.Models;
using Microsoft.EntityFrameworkCore;

namespace ejercicio__crud
{
    public class crudDBcontext : DbContext
    {
        public crudDBcontext()
        {
        }
        public crudDBcontext(DbContextOptions<crudDBcontext>  options) : base(options)
        {

        }
        public DbSet<Decanos> Decanos { get; set; }
        public DbSet<facultad> facultad { get; set; }
        public DbSet<docentes> docentes { get; set; }
        public DbSet<curso> curso { get; set; }
        public DbSet<asignatura> asignatura { get; set; }
        public DbSet<inscripcion> inscripcion { get; set; }
        public DbSet<estudiante> estudiante { get; set; }
    }
}
