using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NHibernate;

namespace WPFSimpleDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ISessionFactory SessionFactory;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SessionFactory = Bootstrapper.Initialize(false);
        }
    }
}
