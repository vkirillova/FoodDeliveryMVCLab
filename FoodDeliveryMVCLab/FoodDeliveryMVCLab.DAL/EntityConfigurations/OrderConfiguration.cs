using ClassLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.DAL.EntityConfigurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.CreatedOn)
                .IsRequired();

            builder.Property(p => p.TotalPrice)
                .IsRequired();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Order> builder)
        {
            
        }
    }
}