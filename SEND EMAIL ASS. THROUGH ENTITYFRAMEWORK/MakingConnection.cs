using Microsoft.EntityFrameworkCore;
using SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK.Entities;

namespace SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK
{
    public class MakingConnection : DbContext
    {
        public DbSet<Items> Item { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public MakingConnection()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3CUF5I;Initial Catalog=EntityFramework;Integrated Security=True");
        }
    }
}
