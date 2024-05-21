using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Login.Model;

namespace Login.View
{
    /// <summary>
    /// Lógica de interacción para PaginaTicket.xaml
    /// </summary>
    public partial class PaginaTicket : Page, INotifyPropertyChanged
    {
        private LoginBibliotecaDataContext miDataContext;


        public PaginaTicket(LoginBibliotecaDataContext miDataContext)
        {
            InitializeComponent();

            this.miDataContext =  miDataContext;
            ActualizarListaTicket();



        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // pARA MOSTRAR LOS DATOS EN LAS LISTBOX
        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }

        private Libro _libro;
        public Libro Libro
        {
            get { return _libro; }
            set
            {
                _libro = value;
                OnPropertyChanged(nameof(Libro));
            }
        }

        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        private void ActualizarListaTicket()
        {
            miDataContext.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, miDataContext.Ticket);
            lsbTicket.ItemsSource = miDataContext.Ticket.ToList();
            foreach (var ticket in miDataContext.Ticket.ToList())
            {
                ticket.Cliente = miDataContext.Cliente.FirstOrDefault(c => c.IdCliente == ticket.IdCliente);
                ticket.Libro = miDataContext.Libro.FirstOrDefault(l => l.IdLibro == ticket.IdLibro);
                ticket.Usuario = miDataContext.Usuario.FirstOrDefault(u => u.IdUsuario == ticket.IdUsuario);
            }
            lsbTicket.ItemsSource = miDataContext.Ticket.ToList();
        }

        // Limpiar los textbox
        private void LimpiarTextBoxes()
        {
            txtDniCliente.Text = string.Empty;
            txtNombreLibro.Text = string.Empty;
            txtMonto.Text = string.Empty;


        }

        private void btnBuscarTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int dni = int.Parse(txtDniCliente.Text);
                string nombreLibro = txtNombreLibro.Text;
                int monto = int.Parse(txtMonto.Text);
                DateTime fecha = DateTime.Now; // Obtener la fecha seleccionada o la fecha actual si es null
                int usuario = int.Parse(txtIdUsuario.Text);

                PaginaTicketModel.AgregarTicket(dni, nombreLibro, monto, fecha, usuario, miDataContext);

                // Actualizar lista de tickets y limpiar textboxes si es necesario
                ActualizarListaTicket();
                LimpiarTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizarTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
