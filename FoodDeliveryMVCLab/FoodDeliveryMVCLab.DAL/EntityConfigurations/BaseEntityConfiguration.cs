using System;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.EntityConfigurations.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryMVCLab.DAL.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityConfiguration<T> where T : class, IEntity
    {
        public Action<EntityTypeBuilder<T>> ProvideConfigurationAction()
        {
            return ConfigureEntity;
        }

        private void ConfigureEntity(EntityTypeBuilder<T> builder)
        {
            ConfigureProperties(builder);
            ConfigurePrimaryKeys(builder);
            ConfigureForeignKeys(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<T> builder) { }

        protected virtual void ConfigurePrimaryKeys(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }

        protected virtual void ConfigureForeignKeys(EntityTypeBuilder<T> builder) { }
    }
}
