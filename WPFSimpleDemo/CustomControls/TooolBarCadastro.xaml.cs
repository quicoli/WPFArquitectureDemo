using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFSimpleDemo.CustomControls
{
    /// <summary>
    /// Interaction logic for TooolBarCadastro.xaml
    /// </summary>
    public partial class TooolBarCadastro : UserControl
    {
        public TooolBarCadastro()
        {
            InitializeComponent();
        }

        [Bindable(true)]
        public ICommand CmdInserir
        {
            get { return (ICommand)GetValue(CmdInserirProperty); }
            set
            {
                SetValue(CmdInserirProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdEditar
        {
            get { return (ICommand)GetValue(CmdEditarProperty); }
            set
            {
                SetValue(CmdEditarProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdExcluir
        {
            get { return (ICommand)GetValue(CmdExcluirProperty); }
            set
            {
                SetValue(CmdExcluirProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdSalvar
        {
            get { return (ICommand)GetValue(CmdSalvarProperty); }
            set
            {
                SetValue(CmdSalvarProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdPesquisar
        {
            get { return (ICommand)GetValue(CmdPesquisarProperty); }
            set
            {
                SetValue(CmdPesquisarProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdCancelar
        {
            get { return (ICommand)GetValue(CmdCancelarProperty); }
            set
            {
                SetValue(CmdCancelarProperty, value);
            }
        }

        [Bindable(true)]
        public ICommand CmdImprimir
        {
            get { return (ICommand)GetValue(CmdImprimirProperty); }
            set
            {
                SetValue(CmdImprimirProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnInserirVisible
        {
            get { return (Visibility)GetValue(BtnInserirVisibleProperty); }
            set
            {
                SetValue(BtnInserirVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnEditarVisible
        {
            get { return (Visibility)GetValue(BtnEditarVisibleProperty); }
            set
            {
                SetValue(BtnEditarVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnExcluirVisible
        {
            get { return (Visibility)GetValue(BtnExcluirVisibleProperty); }
            set
            {
                SetValue(BtnExcluirVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnSalvarVisible
        {
            get { return (Visibility)GetValue(BtnSalvarVisibleProperty); }
            set
            {
                SetValue(BtnSalvarVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnPesquisarVisible
        {
            get { return (Visibility)GetValue(BtnPesquisarVisibleProperty); }
            set
            {
                SetValue(BtnPesquisarVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnCancelarVisible
        {
            get { return (Visibility)GetValue(BtnCancelarVisibleProperty); }
            set
            {
                SetValue(BtnCancelarVisibleProperty, value);
            }
        }

        [Bindable(true)]
        public Visibility BtnImprimirVisible
        {
            get { return (Visibility)GetValue(BtnImprimirVisibleProperty); }
            set
            {
                SetValue(BtnImprimirVisibleProperty, value);
            }
        }

        public static readonly DependencyProperty CmdInserirProperty =
        DependencyProperty.Register("CmdInserir", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdEditarProperty =
        DependencyProperty.Register("CmdEditar", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdExcluirProperty =
        DependencyProperty.Register("CmdExcluir", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdSalvarProperty =
        DependencyProperty.Register("CmdSalvar", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdCancelarProperty =
        DependencyProperty.Register("CmdCancelar", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdPesquisarProperty =
        DependencyProperty.Register("CmdPesquisar", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CmdImprimirProperty =
        DependencyProperty.Register("CmdImprimir", typeof(ICommand), typeof(TooolBarCadastro), new UIPropertyMetadata(null));

        public static readonly DependencyProperty BtnInserirVisibleProperty =
        DependencyProperty.Register("BtnInserirVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnEditarVisibleProperty =
        DependencyProperty.Register("BtnEditarVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnExcluirVisibleProperty =
        DependencyProperty.Register("BtnExcluirVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnSalvarVisibleProperty =
        DependencyProperty.Register("BtnSalvarVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnCancelarVisibleProperty =
        DependencyProperty.Register("BtnCancelarVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnPesquisarVisibleProperty =
        DependencyProperty.Register("BtnPesquisarVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BtnImprimirVisibleProperty =
        DependencyProperty.Register("BtnImprimirVisible", typeof(Visibility), typeof(TooolBarCadastro), new UIPropertyMetadata(Visibility.Collapsed));
    }
}
