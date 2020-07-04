using ClassLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.DAL.EntityConfigurations
{
    public class DishConfiguration: BaseEntityConfiguration<Dish>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasDefaultValue(0.0M)
                .IsRequired();

            builder.HasIndex(b => b.Name).IsUnique();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Dish> builder)
        {
            builder
                .HasOne(b => b.Restaurant)
                .WithMany(b => b.Dishes)
                .HasForeignKey(b => b.RestaurantId)
                .IsRequired();
        }
    }
}
