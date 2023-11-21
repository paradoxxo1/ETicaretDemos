using Microsoft.EntityFrameworkCore;

namespace ETicaretDemos.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PC-ISA\\SQLEXPRESS; Database=ETicaretDemeDb; Integrated Security=true");
        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Sepet> Sepetim { get; set; }
    }
}
