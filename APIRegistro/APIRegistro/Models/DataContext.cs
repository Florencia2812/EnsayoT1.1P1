using System.Data.Entity;

namespace APIRegistro.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIRegistro.Models.Registro> Registroes { get; set; }
    }
}