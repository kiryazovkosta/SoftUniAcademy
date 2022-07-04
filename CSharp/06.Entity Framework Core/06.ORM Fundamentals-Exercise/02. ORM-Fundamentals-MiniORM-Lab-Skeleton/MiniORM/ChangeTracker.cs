namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public class ChangeTracker<TEntity>
		where TEntity : class, new()
    {
        private readonly IList<TEntity> all;
        private readonly IList<TEntity> added;
        private readonly IList<TEntity> removed;

        private ChangeTracker()
        {
            this.added = new List<TEntity>();
            this.removed = new List<TEntity>();
        }

        public ChangeTracker(IEnumerable<TEntity> entities)
            : this()
        {
            this.all = CloneEntities(entities);
        }

        public IReadOnlyCollection<TEntity> All => (IReadOnlyCollection<TEntity>)this.all;
        public IReadOnlyCollection<TEntity> Added => (IReadOnlyCollection<TEntity>)this.added;
        public IReadOnlyCollection<TEntity> Removed => (IReadOnlyCollection<TEntity>)this.removed;

        public void Add(TEntity entity) => this.added.Add(entity);
        public void Remove(TEntity entity) => this.removed.Add(entity);

        public IEnumerable<TEntity> GetModifiedEntities(DbSet<TEntity> dbSet)
        {
            var modifiedEntities = new List<TEntity>();

            var primaryKeys = typeof(TEntity).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxEntity in this.All)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxEntity).ToArray();

                var entity = dbSet
                    .Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                        .SequenceEqual(primaryKeyValues));

                bool isModifies = IsModified(entity, proxEntity);
                if (isModifies)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private static IList<TEntity> CloneEntities(IEnumerable<TEntity> entities)
        {
            var cloned = new List<TEntity>();
            
            var propertiesToClone = typeof(TEntity).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToList();

            foreach (var originalEntity in entities)
            {
                TEntity clonedEntity = Activator.CreateInstance<TEntity>();
                foreach (var property in propertiesToClone)
                {
                    object originalValue = property.GetValue(originalEntity);
                    property.SetValue(clonedEntity, originalValue);
                }

                cloned.Add(clonedEntity);
            }

            return cloned;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, TEntity entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private static bool IsModified (TEntity original, TEntity proxy)
        {
            var monitoredProperties = typeof(TEntity)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(original), pi.GetValue(proxy)))
                .ToArray();

            return modifiedProperties.Any();
        }
    }
}