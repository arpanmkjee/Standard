﻿using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Core
{
    public interface IAggregateRoot : IEntity, IVersionable { }

    public interface IAggregateRoot<out TKey> : IEntity<TKey>, IAggregateRoot { }

    public interface IAggregateRoot<in TEntity, out TKey> : IEntity<TEntity, TKey>, IAggregateRoot<TKey>
        where TEntity : IAggregateRoot { }

}