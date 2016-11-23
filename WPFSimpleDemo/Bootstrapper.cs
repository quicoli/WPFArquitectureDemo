using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using WPFSimpleDemo.Entities;
using WPFSimpleDemo.Model;
using WPFSimpleDemo.Persistance.NhMapping;

namespace WPFSimpleDemo
{
    public static class Bootstrapper
    {
        public static IMapper Mapper { get; set; }
        private static ISessionFactory _sessionFactory;

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>()
                    .ForMember(s => s.IsValid, c => c.Ignore())
                    .ForMember(s => s.ValidationResults, c => c.Ignore())
                    .ForMember(s => s.ConfirmPassword, c => c.ResolveUsing(y => y.Password));


                cfg.CreateMap<UserModel, User>()
                    .ForSourceMember(s => s.IsValid, c => c.Ignore())
                    .ForSourceMember(s => s.ValidationResults, c => c.Ignore());

            });

            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }

        private static ISessionFactory InitializePersistance(bool createSchema)
        {
            if (_sessionFactory != null)
            {
                return _sessionFactory;
            }

            var fluentConfig = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("userdb.db").ShowSql())
                .Mappings(mapper =>
                {
                    mapper.FluentMappings
                        .AddFromAssemblyOf<UserClassMap>();
                });

            var nhConfiguration = fluentConfig.BuildConfiguration();
            _sessionFactory = nhConfiguration.BuildSessionFactory();

            if (createSchema)
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        new SchemaExport(nhConfiguration).Execute(true, true, false, session.Connection, null);
                        tx.Commit();
                    }
                }
            }

            return _sessionFactory;
        }


        public static ISessionFactory Initialize(bool createSchema)
        {
            MyServiceLocatorProvider.Initialize();
            InitializeAutoMapper();
            return InitializePersistance(createSchema);
        }
    }

}