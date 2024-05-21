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
using System.Windows.Shapes;
using System.Configuration;
using Login.Model;
using System.Runtime.InteropServices;
using System.Security;

namespace Login.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginBibliotecaDataContext miDataContext;
        public LoginView()
        {
            InitializeComponent();

            string miConexion = ConfigurationManager.ConnectionStrings["Login.Properties.Settings.LoginConLinq"].ConnectionString;

            miDataContext = new LoginBibliotecaDataContext(miConexion);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtUser.Text;
            // Obtener el valor del PasswordBox
            string password = ConvertSecureStringToString(txtPass.SecurePassword);

            LoginPrincipal.VerificacionLogin(miDataContext, nombre, password, this);
        }

        //Funcion para pasr el password a text
        private string ConvertSecureStringToString(SecureString secureString)
        {
            // Si secureString es null, devolver una cadena vacía
            if (secureString == null)
                return string.Empty;

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                // Convertir SecureString a una cadena no segura (unmanaged)
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Liberar la memoria asignada para la cadena no segura
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }


        

    }

}
