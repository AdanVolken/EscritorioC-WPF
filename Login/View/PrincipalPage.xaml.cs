using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Configuration;
using System.Data.Linq;
using Login.Model;

namespace Login.View
{
    /// <summary>
    /// Lógica de interacción para PrincipalPage.xaml
    /// </summary>
    public partial class PrincipalPage : Window
    {
        private LoginBibliotecaDataContext miDataContext;
        public PrincipalPage()
        {
            InitializeComponent();

            string miConexion = ConfigurationManager.ConnectionStrings["Login.Properties.Settings.LoginConLinq"].ConnectionString;

            miDataContext = new LoginBibliotecaDataContext(miConexion);


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
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            

        }


        private void RadioButton_Click_Cliente(object sender, RoutedEventArgs e)
        {
            fCliente.Content = new PaginaCliente(miDataContext);
        }
        private void RadioButton_Click_Libro(object sender, RoutedEventArgs e)
        {
            fCliente.Content = new PaginaLibro(miDataContext);
        }

        private void RadioButton_Click_Ticket(object sender, RoutedEventArgs e)
        {
            fCliente.Content = new PaginaTicket(miDataContext);
        }
    }
}
