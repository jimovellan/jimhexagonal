using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Models
{
    
    public abstract class AggregateRoot:EntityBase
    {
        private List<DomainEvent> _events = new List<DomainEvent>();
        public IReadOnlyCollection<DomainEvent>  Events => _events;

        public AggregateRoot():base()
        {
           
        }

        /// <summary>
        /// Add an domain event
        /// </summary>
        /// <param name="domainEvent"></param>
        void AddEvent(DomainEvent domainEvent) => _events.Add(domainEvent);
        
        /// <summary>
        /// Clean all events
        /// </summary>
        void ClearEvents() => _events.Clear();
    }
}
