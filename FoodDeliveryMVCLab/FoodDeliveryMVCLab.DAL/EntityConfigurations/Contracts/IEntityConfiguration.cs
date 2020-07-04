using System;
using ClassLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.DAL.EntityConfigurations.Contracts
{
    public interface IEntityConfiguration<T> where T : class, IEntity
    {
        Action<EntityTypeBuilder<T>> ProvideConfigurationAction();
    }
}