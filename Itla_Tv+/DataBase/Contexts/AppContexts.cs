using DataBase.Models;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Contexts
{
    public class AppContexts : DbContext
    {
        public AppContexts(DbContextOptions<AppContexts> options) : base (options) { }
        public DbSet<Series> Series { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region table
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Series>().HasKey(Series => Series.Id);
            modelBuilder.Entity<Category>().HasKey(Category => Category.Id);

            #endregion

            #region relationships
            modelBuilder.Entity<Category>()
                .HasMany<Series>(Category => Category.Serie)
                .WithOne(Series => Series.Category)
                .HasForeignKey(Series
                => Series.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region "property configurations"

            #endregion
            #region "Series"
            modelBuilder.Entity<Series>().Property(S => S.Name)
                .IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Series>().Property(S => S.Genero)
    .IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Series>().Property(S => S.Productora)
    .IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Series>().Property(S => S.Trailer)
    .IsRequired().HasMaxLength(200);

            #endregion
            #region "Category
            modelBuilder.Entity<Category>().Property(S => S.Name)
    .IsRequired().HasMaxLength(150);
            #endregion



        }

    }
    }

