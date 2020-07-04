using ClassLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.DAL.EntityConfigurations
{
    public class RestaurantConfiguration : BaseEntityConfiguration<Restaurant>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(b => b.Name).IsUnique();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Restaurant> builder)
        {
            builder
                .HasMany(b => b.Dishes)
                .WithOne(b => b.Restaurant)
                .HasForeignKey(b => b.RestaurantId)
                .IsRequired();
        }
    }
}