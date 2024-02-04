using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace EncryptionWithEF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<User> User { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //        optionsBuilder.UseSqlServer("Data Source=.,1456;Initial Catalog=EncryptionDb;Persist Security Info=True;User ID=sa;Password=Salman#2241371;TrustServerCertificate=True") ;

        //}
        private readonly EncryptionService _encryptionService = new EncryptionService();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var encryptionConverter = new EncryptionConverter(_encryptionService);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasConversion(encryptionConverter);
            EncryptionConverter encryptionConverter1 = encryptionConverter;
            modelBuilder.Entity<User>()
                .Property<string>(u => u.PhoneNumber)
                .HasConversion(encryptionConverter1);
        }
    }
}
