using ClassLibrary.DAL.Entities;
using ClassLibrary.DAL.EntityConfigurations.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly IEntityConfigurationsContainer _entityConfigurationsContainer;
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions options,
            IEntityConfigurationsContainer entityConfigurationsContainer) : base(options)
        {
            _entityConfigurationsContainer = entityConfigurationsContainer;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(_entityConfigurationsContainer.DishConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.RestaurantConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.OrderConfiguration.ProvideConfigurationAction());
        }
    }
}