using System;

namespace WPFSimpleDemo.Entities
{
    public class BaseEntity<T> where T : BaseEntity<T>
    {
        public virtual Int64 Id { get; set; }


        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;

            var ehTransiente = Id == 0;
            if (ehTransiente)
            {
                _hashCode = base.GetHashCode();
                return _hashCode.Value;
            }
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var outro = obj as T;
            if (outro == null) return false;

            var esteEhTransiente = Id == 0;
            var outroEhTransiente = outro.Id == 0;

            if (esteEhTransiente && outroEhTransiente)
                return ReferenceEquals(this, outro);

            return Id == outro.Id;
        }


        public static bool operator ==(BaseEntity<T> lhs, BaseEntity<T> rhs)
        {
            return Equals(lhs, rhs);
        }


        public static bool operator !=(BaseEntity<T> lhs, BaseEntity<T> rhs)
        {
            return !Equals(lhs, rhs);
        }
    }
}