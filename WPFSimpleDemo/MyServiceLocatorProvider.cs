using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alphacloud.Common.ServiceLocator.Castle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using WPFSimpleDemo.Persistance.CustomType;
using WPFSimpleDemo.Validation;

namespace WPFSimpleDemo
{
    public class MyServiceLocatorProvider
    {
        private static WindsorContainer _container = null;

        private MyServiceLocatorProvider()
        {
        }

        public static WindsorContainer Container
        {
            get { return _container ?? (_container = new WindsorContainer()); }
            set { _container = value; }

        }

        public static void Initialize()
        {
            var sl = new WindsorServiceLocatorAdapter(Container);
            Container.Register(Component.For<IPasswordRule>().ImplementedBy<DefaultPasswordRule>().LifeStyle.Transient);
            Container.Register(Component.For<IStringCipher>().ImplementedBy<DefaultStringCipher>().LifeStyle.Transient);
            ServiceLocator.SetLocatorProvider(() => sl);
        }
    }
}
