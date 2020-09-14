using System.Data.Entity;

namespace admRegistro.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admRegistro.Models.Registro> Registroes { get; set; }
    }
}