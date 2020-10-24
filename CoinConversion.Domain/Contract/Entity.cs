using System;

namespace CoinConversion.Domain.Contract
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}