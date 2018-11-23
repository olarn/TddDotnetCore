using Microsoft.EntityFrameworkCore;

namespace TaxRepo
{
    public class TaxContext : DbContext
    {
        public TaxContext(DbContextOptions<TaxContext> options) : base(options) { }
        public DbSet<Vat> Vats { get; set; }
    }
}