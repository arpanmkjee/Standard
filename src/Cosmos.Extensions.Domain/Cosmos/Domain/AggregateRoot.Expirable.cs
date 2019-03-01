using Cosmos.Domain.Core;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain
{
    public abstract class ExpirableAggregateRoot<TEntity, TKey> : ExpirableEntityBase<TEntity, TKey>, IAggregateRoot<TEntity, TKey>
        where TEntity : class, IAggregateRoot, IValidatable<TEntity>
    {
        protected ExpirableAggregateRoot() : base() { }

        protected ExpirableAggregateRoot(TKey id) : base(id) { }

        public byte[] Version { get; set; }
    }
}