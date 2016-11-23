using System;
using System.Data;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace WPFSimpleDemo.Persistance.CustomType
{
    public class EncryptedString : IUserType
    {
        private const string Pass = "XYZO1";

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return x.Equals(y);

        }

        public int GetHashCode(object x)
        {
            throw new NotImplementedException();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            object passwordString = NHibernateUtil.String.NullSafeGet(rs, names[0]);
            return passwordString != null ?  ServiceLocator.Current.GetInstance<IStringCipher>().Decrypt((string)passwordString) : null;
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
            string encryptedValue = ServiceLocator.Current.GetInstance<IStringCipher>().Encrypt((string)value);
            NHibernateUtil.String.NullSafeSet(cmd, encryptedValue, index);
        }

        public object DeepCopy(object value)
        {
            return value == null ? null : string.Copy((string)value);
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

        public SqlType[] SqlTypes
        {
            get { return new[] { new SqlType(DbType.String) }; }
        }

        public Type ReturnedType
        {
            get { return typeof(string); }
        }

        public bool IsMutable
        {
            get { return false; }
        }

        public int GetHasCode(object x)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            return x.GetHashCode();
        }
    }
}