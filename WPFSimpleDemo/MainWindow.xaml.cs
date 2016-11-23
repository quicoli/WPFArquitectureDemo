using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JulMar.Core;
using JulMar.Core.Interfaces;
using JulMar.Windows.Mvvm;
using WPFSimpleDemo.Messages;

namespace WPFSimpleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMessageMediator _messageMediator = ViewModel.ServiceProvider.Resolve<IMessageMediator>();

        public MainWindow()
        {
            InitializeComponent();
            _messageMediator.Register(this);
            DataContext = new MainViewModel();
        }

        [MessageMediatorTarget(Constants.Messages.EditMessage)]
        public void OnEditing(EditMessage message)
        {
            if (message.ViewModel == DataContext)
            {
                TextBoxUserName.Focus();
                Keyboard.Focus(TextBoxUserName);
            }
        }

        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _messageMediator.Unregister(this);
        }
    }
}
