using System;
using FoodDeliveryMVCLab.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryMVCLab.DAL.EntityConfigurations.Contracts
{
    public interface IEntityConfiguration<T> where T : class, IEntity
    {
        Action<EntityTypeBuilder<T>> ProvideConfigurationAction();
    }
}