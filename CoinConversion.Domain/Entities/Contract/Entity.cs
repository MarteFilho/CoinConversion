using System;
using Flunt.Notifications;

namespace CoinConversion.Domain.Entities
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
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