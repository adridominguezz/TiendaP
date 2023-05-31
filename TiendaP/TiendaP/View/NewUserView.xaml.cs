using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiendaP.Models;

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para NewUserView.xaml
    /// </summary>
    public partial class NewUserView : Window
    {
        public NewUserView()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            User usuario = new User();
            usuario.Name = txtName.Text;
            usuario.LastName = txtSurname.Text;
            usuario.Email = txtEmail.Text;
            usuario.Username = txtUser.Text;
            usuario.Password = txtPassword.Text;
            usuario.Tipo = "cliente";


            Console.Write(usuario);
            bool error = false;

            try
            {
                int resultado = INewUserRepository.CrearUsuario(usuario);
                if (resultado > 0)
                {
                    usuarioCreado.Text = "Se han guardado correctamente";
                }
                else
                {
                    error = true;
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                usuarioCreado.Text = "No se pudieron guardar los datos";
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la ventana actual
            this.Close();

        }
    }
}
