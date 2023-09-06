using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using backend_API.Models.Activity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_API.Data
{
    public class CCGToolsDbContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityCategory> ActivityCategory { get; set; }
        public DbSet<ActivityCategoryState> ActivityCategoryState { get; set; }
        public DbSet<ActivityWorkerProfile> ActivityWorkerProfile { get; set; }
        public DbSet<WorkerProfile> WorkerProfile { get; set; }

        private readonly IConfiguration configuration;

        public CCGToolsDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("DatabaseConnectionString");

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 24)));
        }



        //public CCGToolsDbContext(DbContextOptions options) : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "server=localhost;port=3306;database=gptools;user=ccg;password=1234;AllowZeroDateTime=True";

        //    optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 24)));
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Activity>()
        //        .HasOne(a => a.Parent)
        //        .WithMany(a => a.Child)
        //        .HasForeignKey(a => a.ParentId)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    // Configurações para outras entidades...

        //    base.OnModelCreating(modelBuilder);
        //}

        //public void Configure(EntityTypeBuilder<WorkerProfile> builder)
        //{
        //    builder.HasKey(e => e.Id);
        //    builder.Property(e => e.Id)
        //        .ValueGeneratedOnAdd(); //autoincromentar Id

        //}

        //// correto
        //public void Configure(EntityTypeBuilder<Activity> builder)
        //{
        //    // Autoincrement Id
        //    builder.HasKey(e => e.Id);
        //    builder.Property(e => e.Id)
        //        .ValueGeneratedOnAdd();

        //    // Delete restrited relacionado com ActivityWorkerProfile


        //}     

    }
}
