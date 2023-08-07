using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Models
{
    public abstract class DomainEvent
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DomainEvent()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }

    }

    public abstract class DomainEvent<T> : DomainEvent
    {
        public T Value { get; private set; }

        public DomainEvent( T value):base()
        {
            Value = value;
        }
    }
}
