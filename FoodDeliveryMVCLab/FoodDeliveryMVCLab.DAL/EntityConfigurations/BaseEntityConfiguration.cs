using System;
using ClassLibrary.DAL.Entities;
using ClassLibrary.DAL.EntityConfigurations.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.DAL.EntityConfigurations
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
