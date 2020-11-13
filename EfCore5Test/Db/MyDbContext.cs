using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace EfCore5Test.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<FirstModel> Firsts { get; set; }
        public DbSet<SecondModel> Seconds { get; set; }
        public DbSet<MyCoolModel> MyCoolModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<MyCoolModel>();

            entityBuilder.OwnsOne(record => record.Id, p =>
            {
                var properties = p.OwnedEntityType.ClrType.GetProperties();
                foreach (var property in properties)
                {
                    var propertyType = property.PropertyType;

                    // Set column name for owned type to name of property
                    // This is ignored and prefixed with the owned type name, when the column already exists from another property. 
                    p.Property(propertyType, property.Name).HasColumnName(property.Name);

                    // Include property as a shadow property (if not in model). 
                    // If not added, HasKey fails. 
                    entityBuilder.Property(propertyType, property.Name);
                }

                entityBuilder.HasKey(properties.Select(x => x.Name).ToArray());
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
