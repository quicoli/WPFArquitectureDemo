using FluentNHibernate.Mapping;
using WPFSimpleDemo.Entities;
using WPFSimpleDemo.Persistance.CustomType;

namespace WPFSimpleDemo.Persistance.NhMapping
{
    public class UserClassMap: ClassMap<User>
    {
        public UserClassMap()
        {
            Table("UserTable");
            Id(x => x.Id).GeneratedBy.HiLo("50");
            Map(x => x.UserName).Index("UserIdx1");
            Map(x => x.Password).CustomType<EncryptedString>().Index("UserIdx2");
        }
    }
}