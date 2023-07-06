using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.Demo.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            var compareTo = obj as BaseEntity;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;
            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false; 
            return a.Id.Equals(b.Id);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 13) + Id.GetHashCode();
        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
