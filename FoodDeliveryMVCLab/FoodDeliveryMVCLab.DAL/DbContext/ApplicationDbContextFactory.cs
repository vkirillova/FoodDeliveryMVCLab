using System;
using ClassLibrary.DAL.EntityConfigurations.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.DAL.DbContext
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }

    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions _options;
        private readonly IEntityConfigurationsContainer _entityConfigurationsContainer;

        public ApplicationDbContextFactory(DbContextOptions options, IEntityConfigurationsContainer entityConfigurationsContainer)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (entityConfigurationsContainer == null)
                throw new ArgumentNullException(nameof(entityConfigurationsContainer));

            _options = options;
            _entityConfigurationsContainer = entityConfigurationsContainer;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(_options, _entityConfigurationsContainer);
        }
    }
}
