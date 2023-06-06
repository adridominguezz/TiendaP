using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using TiendaP.Models;
using TiendaP.Repositories;
using TiendaP.View;

namespace TiendaP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        public UserAccountModel _currentUserAccount;

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        //Propiedades
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
    public IconChar Icon {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Comandos
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCestaViewCommand { get; }
        public ICommand ShowCuentaViewCommand { get; }
        public ICommand ShowFAQViewCommand { get; }
        public ICommand ShowContactoViewCommand { get; }
        public ICommand ShowComprasViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Inicializar comandos
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCestaViewCommand = new ViewModelCommand(ExecuteShowCestaViewCommand);
            ShowCuentaViewCommand = new ViewModelCommand(ExecuteShowCuentaViewCommand);
            ShowFAQViewCommand = new ViewModelCommand(ExecuteShowFAQViewCommand);
            ShowContactoViewCommand = new ViewModelCommand(ExecuteShowContactoViewCommand);
            ShowComprasViewCommand = new ViewModelCommand(ExecuteShowComprasViewCommand);


            //Vista predeterminada
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }
        public string GetUserId()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
           return user.Id;
        }

        public bool IsAdmin
        {
            get { return _currentUserAccount.Tipo == "admin"; }
        }

        public bool IsAdminOrDepen
        {
            get { return (_currentUserAccount.Tipo == "admin" || _currentUserAccount.Tipo == "Depen"); }
        }



        private void ExecuteShowContactoViewCommand(object obj)
        {
            CurrentChildView = new ContactoViewModel();
            Caption = "Contacto";
            Icon = IconChar.EnvelopesBulk;
        }

        private void ExecuteShowFAQViewCommand(object obj)
        {
            CurrentChildView = new FAQViewModel();
            Caption = "Cesta";
            Icon = IconChar.ClipboardQuestion;
        }

        private void ExecuteShowCuentaViewCommand(object obj)
        {
            CurrentChildView = new CuentaViewModel();
            Caption = "Cuenta";
            Icon = IconChar.UserAlt;
        }

        private void ExecuteShowCestaViewCommand(object obj)
        {
            CurrentChildView = new CestaViewModel();
            Caption = "Cesta";
            Icon = IconChar.BagShopping;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Tienda";
            Icon = IconChar.Home;
        }
        private void ExecuteShowComprasViewCommand(object obj)
        {
            CurrentChildView = new ComprasViewModel();
            Caption = "Compras";
            Icon = IconChar.CashRegister;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Id = user.Id;
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.Tipo = user.Tipo; 
                OnPropertyChanged(nameof(IsAdmin));

            }
        }

        public Visibility IsAdminVisibility
        {
            get { return IsAdmin ? Visibility.Visible : Visibility.Collapsed; }
        }
        public Visibility IsAdminOrDepenVisibility
        {
            get { return IsAdminOrDepen ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
