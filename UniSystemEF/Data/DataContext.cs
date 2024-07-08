using Microsoft.EntityFrameworkCore;
using UniSystemEF.Configuration;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.Data
{
    public class DataContext : DbContext
    {
        private static DataContext? instance;
        public static DataContext Instance
        {
            get
            {
                return instance ??= new DataContext();
            }
            set
            {
                instance = value;
            }
        }

        private readonly string _connectionString = "Server=localhost;Database=University;TrustServerCertificate=true;Trusted_Connection=true;";
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new GroupConfig());
            modelBuilder.ApplyConfiguration(new FacultyConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());

            }
        }
    }
}
